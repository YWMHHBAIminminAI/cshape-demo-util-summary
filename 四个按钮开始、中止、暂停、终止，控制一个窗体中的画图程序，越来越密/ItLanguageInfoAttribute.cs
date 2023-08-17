using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class ItLanguageInfoAttribute : Attribute
    {
        #region 私有变量
        /// <summary>
        /// 私有变量
        /// </summary>
        private string name; //名称
		private string phylum; //门
		private string classis; //纲
		private string familia; //科
        #endregion

        #region
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nameValue"></param>
        /// <param name="familiaValue"></param>
        public ItLanguageInfoAttribute(string nameValue, string familiaValue)
		{
			name = nameValue;
			familia = familiaValue;
		}
		#endregion

		#region 属性
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get { return familia; }
			set { familia = value; }
		}


		public string Phylum
        {
			get { return classis; }
			set { classis = value; }
		}


		public string Classis
        {
			get { return phylum; }
			set { phylum = value; }
		}


		public string Familia
        {
			get { return name; }
			set { name = value; }
		}
        #endregion

    }
}
