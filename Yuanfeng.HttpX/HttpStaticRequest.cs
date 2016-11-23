using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Services.Description;
using Yuanfeng.Smarty;

namespace Yuanfeng.HttpX
{
    public class HttpStaticRequest
    {
        public delegate void ASyncResultCallback(object result);
        #region InvokeWebService

        /// <summary>
        /// 动态调用web服务
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="@namespace">默认命名空间</param>
        /// <param name="methodname">方法名称</param>
        /// <param name="args">参数列表</param>
        /// <returns></returns>
        public static string InvokeWebService(string url, string methodname, object[] args)
        {
            return InvokeWebService(url, "Yuanfeng.HttpX", methodname, args);
        }
        /// <summary>
        /// 动态调用web服务
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="@namespace">默认命名空间</param>
        /// <param name="methodname">方法名称</param>
        /// <param name="args">参数列表</param>
        /// <returns></returns>
        public static string InvokeWebService(string url, string @namespace, string methodname, object[] args)
        {
            string reqVal = string.Empty;
            try
            {
                CancellableTask.WorkCallback workCallBack = delegate (object obj)
                {
                    object val = "";
                    try
                    {
                        val = InvokeWebService(url, @namespace, null, methodname, args);
                    }
                    catch (Exception exception)
                    {
                        SimpleConsole.WriteLine(exception);
                        val = "请求地址不存在或参数错误";
                    }
                    reqVal = val.ToString();
                    return val;
                };
                CancellableTask.CancelCallback cacelCallBack = delegate (object obj)
                {
                    reqVal = "请求超时，已被取消";
                };
                CancellableTask task = new CancellableTask(workCallBack, cacelCallBack);

                AsyncCallback asyncCallback = delegate (IAsyncResult obj)
                {
                    try { task.EndInvoke(obj); } catch { }
                    SimpleConsole.WriteLine("AsyncCallback");
                };

                var result = task.BeginInvoke(null, asyncCallback, null, 15 * 1000);
                try
                {
                    object endResult = task.EndInvoke(result);
                    SimpleConsole.WriteLine(endResult);
                }
                catch (Exception exception)
                {
                    SimpleConsole.WriteLine(exception);
                }
            }
            catch (Exception exception)
            {
                reqVal = exception.Message;
            }
            return reqVal;
        }

        /// <summary>
        /// 动态调用web服务
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="@namespace">默认命名空间</param>
        /// <param name="methodname">方法名称</param>
        /// <param name="args">参数列表</param>
        /// <returns></returns>
        public static void InvokeWebService(string url, string methodname, object[] args, ASyncResultCallback resultcallback)
        {
            CancellableTask task = new CancellableTask(new CancellableTask.WorkCallback((object obj) =>
            {
                try
                {
                    return InvokeWebService(url, "Yuanfeng.HttpX", null, methodname, args);
                }
                catch (Exception exception) { return "请求地址不存在或请求参数错误，" + exception.Message; }
            }), new CancellableTask.CancelCallback((object obj) =>
            {
                object result = null; result = "请求被取消"; resultcallback(result);
            }));

            task.BeginInvoke(new object[] { url, methodname, args }, new AsyncCallback((IAsyncResult iresult) =>
            {
                object result = null;
                try
                {
                    result = task.EndInvoke(iresult);
                }
                catch { result = "请求超时"; }
                resultcallback.Invoke(result);
            }), null, 15 * 1000);
        }

        /// <summary>
        /// 动态调用web服务
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="@namespace">默认命名空间</param>
        /// <param name="methodname">方法名称</param>
        /// <param name="args">参数列表</param>
        /// <returns></returns>
        public static void InvokeWebService(string url, string @namespace, string methodname, object[] args, ASyncResultCallback resultcallback)
        {
            CancellableTask task = new CancellableTask(new CancellableTask.WorkCallback((object obj) =>
            {
                try
                {
                    return InvokeWebService(url, @namespace, null, methodname, args);
                }
                catch (Exception exception) { return "请求地址不存在或请求参数错误，" + exception.Message; }
            }), new CancellableTask.CancelCallback((object obj) =>
            {
                object result = null; result = "请求被取消"; resultcallback(result);
            }));

            task.BeginInvoke(new object[] { url, methodname, args }, new AsyncCallback((IAsyncResult iresult) =>
            {
                object result = null;
                try
                {
                    result = task.EndInvoke(iresult);
                }
                catch { result = "请求超时"; }
                resultcallback.Invoke(result);
            }), null, 15 * 1000);
        }

        private static object InvokeWebService(string url, string @namespace, string classname, string methodname, object[] args)
        {
            if ((classname == null) || (classname == ""))
            {
                classname = GetWsClassName(url);
            }

            try
            {
                //获取WSDL
                WebClient wc = new WebClient();
                using (Stream stream = wc.OpenRead(url + "?WSDL"))
                {
                    ServiceDescription sd = ServiceDescription.Read(stream);
                    ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                    sdi.AddServiceDescription(sd, "", "");
                    CodeNamespace cn = new CodeNamespace(@namespace);

                    //生成客户端代理类代码
                    CodeCompileUnit ccu = new CodeCompileUnit();
                    ccu.Namespaces.Add(cn);
                    sdi.Import(cn, ccu);
                    CSharpCodeProvider csc = new CSharpCodeProvider();
                    ICodeCompiler icc = csc.CreateCompiler();

                    //设定编译参数
                    CompilerParameters cplist = new CompilerParameters();
                    cplist.GenerateExecutable = false;
                    cplist.GenerateInMemory = true;
                    cplist.ReferencedAssemblies.Add("System.dll");
                    cplist.ReferencedAssemblies.Add("System.XML.dll");
                    cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                    cplist.ReferencedAssemblies.Add("System.Data.dll");

                    //编译代理类
                    CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
                    if (true == cr.Errors.HasErrors)
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                        {
                            sb.Append(ce.ToString());
                            sb.Append(System.Environment.NewLine);
                        }
                        throw new Exception(sb.ToString());
                    }

                    //生成代理实例，并调用方法
                    System.Reflection.Assembly assembly = cr.CompiledAssembly;
                    Type t = assembly.GetType(@namespace + "." + classname, true, true);
                    object obj = Activator.CreateInstance(t);
                    System.Reflection.MethodInfo mi = t.GetMethod(methodname);

                    return mi.Invoke(obj, args);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
        }

        private static string GetWsClassName(string wsUrl)
        {
            string[] parts = wsUrl.Split('/');
            string[] pps = parts[parts.Length - 1].Split('.');

            return pps[0];
        }
        #endregion
    }
}
