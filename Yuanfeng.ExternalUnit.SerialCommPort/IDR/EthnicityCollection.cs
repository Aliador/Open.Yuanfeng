using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.ExternalUnit.SerialCommPort.IDR
{
    public class EthnicityCollection : IList<string>
    {
        private string[] nationArray = new string[]
        {
            "",
            "汉",
            "蒙古",
            "回",
            "藏",
            "维吾尔",
            "苗",
            "彝",
            "壮",
            "布依",
            "朝鲜",
            "满",
            "侗",
            "瑶",
            "白",
            "土家",
            "哈尼",
            "哈萨克",
            "傣",
            "黎",
            "傈僳",
            "佤",
            "畲",
            "高山",
            "拉祜",
            "水",
            "东乡",
            "纳西",
            "景颇",
            "柯尔克孜",
            "土",
            "达斡尔",
            "仫佬",
            "羌",
            "布朗",
            "撒拉",
            "毛南",
            "仡佬",
            "锡伯",
            "阿昌",
            "普米",
            "塔吉克",
            "怒",
            "乌孜别克",
            "俄罗斯",
            "鄂温克",
            "德昂",
            "保安",
            "裕固",
            "京",
            "塔塔尔",
            "独龙",
            "鄂伦春",
            "赫哲",
            "门巴",
            "珞巴",
            "基诺"
        };

        public string this[int index]
        {
            get
            {
                return nationArray[index];
            }

            set
            {

            }
        }        

        public int Count
        {
            get
            {
                return nationArray.Length;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public void Add(string item)
        {
            
        }

        public void Clear()
        {
            
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(string item)
        {
            return nationArray.Contains(item);
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            //throw new NotImplementedException();
        }

        public IEnumerator<string> GetEnumerator()
        {
            return null;
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(string item)
        {
            return -1; //throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, string item)
        {
            //throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string item)
        {
            return false;//throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            //throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return nationArray.GetEnumerator();
        }
    }
}
