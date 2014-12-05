using System;
using System.Collections.Generic;
using System.Web;
using MyBase.MyWap;
using Alipay.Class;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;

namespace WapTest
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    public class h : MyWapBase
    {
      
        public override void WriteHTML()
        {
            Write(MyUtility.MySecurity.AESEncrypt_Simple("localhost", "LinhamNhu@#123"));
        }

        //[ { "STT" : "1" , "Name" : "B\u00E1o c\u00E1o v\u1EC1 t\u1ED5 ch\u1EE9c l\u1EC5 h\u1ED9i do c\u1EA5p huy\u1EC7n t\u1ED5 ch\u1EE9c" , "LinhVucName" : "V\u0103n h\u00F3a" , "CqThName" : "S\u1EDF V\u0103n h\u00F3a, Th\u1EC3 thao v\u00E0 Du l\u1ECBch" , "IsNew" : false , "Id" : 138 },{ "STT" : "2" , "Name" : "B\u00E1o c\u00E1o v\u1EC1 T\u1ED5 ch\u1EE9c l\u1EC5 h\u1ED9i do c\u1EA5p t\u1EC9nh t\u1ED5 ch\u1EE9c" , "LinhVucName" : "V\u0103n h\u00F3a" , "CqThName" : "B\u1ED9 V\u0103n h\u00F3a, Th\u1EC3 thao v\u00E0 Du l\u1ECBch" , "IsNew" : false , "Id" : 72 },{ "STT" : "3" , "Name" : "C\u1EA5p bi\u1EC3n hi\u1EC7u \u0111\u1EA1t ti\u1EC3u chu\u1EA9n ph\u1EE5c v\u1EE5 kh\u00E1ch du l\u1ECBch \u0111\u1ED1i v\u1EDBi c\u01A1 s\u1EDF kinh doanh d\u1ECBch v\u1EE5 \u0103n u\u1ED1ng du l\u1ECBch" , "LinhVucName" : "Du l\u1ECBch" , "CqThName" : "S\u1EDF V\u0103n h\u00F3a, Th\u1EC3 thao v\u00E0 Du l\u1ECBch" , "IsNew" : false , "Id" : 160 },{ "STT" : "4" , "Name" : "C\u1EA5p bi\u1EC3n hi\u1EC7u \u0111\u1EA1t ti\u1EC3u chu\u1EA9n ph\u1EE5c v\u1EE5 kh\u00E1ch du l\u1ECBch \u0111\u1ED1i v\u1EDBi c\u01A1 s\u1EDF kinh doanh d\u1ECBch v\u1EE5 mua s\u1EAFm du l\u1ECBch" , "LinhVucName" : "Du l\u1ECBch" , "CqThName" : "S\u1EDF V\u0103n h\u00F3a, Th\u1EC3 thao v\u00E0 Du l\u1ECBch" , "IsNew" : false , "Id" : 161 },{ "STT" : "5" , "Name" : "C\u00F4ng nh\u1EADn Gia \u0111\u00ECnh V\u0103n h\u00F3a" , "LinhVucName" : "V\u0103n h\u00F3a" , "CqThName" : "Ban V\u1EADn \u0111\u1ED9ng \u201CTo\u00E0n d\u00E2n \u0111o\u00E0n k\u1EBFt x\u00E2y d\u1EF1ng \u0111\u1EDDi s\u1ED1ng v\u0103n h\u00F3a \u1EDF khu d\u00E2n c\u01B0\u201D t\u1EA1i khu v\u1EF1c sinh s\u1ED1ng c\u1EA5p x\u00E3 " , "IsNew" : false , "Id" : 184 },{ "STT" : "6" , "Name" : "Th\u1EE7 t\u1EE5c b\u00E1o c\u00E1o v\u1EC1 T\u1ED5 ch\u1EE9c l\u1EC5 h\u1ED9i do c\u1EA5p x\u00E3 t\u1ED5 ch\u1EE9c" , "LinhVucName" : "V\u0103n h\u00F3a" , "CqThName" : "Ph\u00F2ng V\u0103n ho\u00E1 - Th\u00F4ng tin" , "IsNew" : false , "Id" : 174 },{ "STT" : "6" , "Name" : "Th\u1EE7 t\u1EE5c b\u00E1o c\u00E1o v\u1EC1 T\u1ED5 ch\u1EE9c l\u1EC5 h\u1ED9i do c\u1EA5p x\u00E3 t\u1ED5 ch\u1EE9c" , "LinhVucName" : "V\u0103n h\u00F3a" , "CqThName" : "Ph\u00F2ng V\u0103n ho\u00E1 - Th\u00F4ng tin" , "IsNew" : false , "Id" : 14 },{ "STT" : "8" , "Name" : "Th\u1EE7 t\u1EE5c c\u1EA5p ch\u1EE9ng ch\u1EC9 h\u00E0nh ngh\u1EC1 mua b\u00E1n di v\u1EADt, c\u1ED5 v\u1EADt, b\u1EA3o v\u1EADt qu\u1ED1c gia" , "LinhVucName" : "V\u0103n h\u00F3a" , "CqThName" : "S\u1EDF V\u0103n h\u00F3a, Th\u1EC3 thao v\u00E0 Du l\u1ECBch" , "IsNew" : false , "Id" : 105 },{ "STT" : "9" , "Name" : "Th\u1EE7 t\u1EE5c c\u1EA5p gi\u1EA5y ch\u1EE9ng nh\u1EADn \u0111\u0103ng k\u00FD quy\u1EC1n li\u00EAn quan" , "LinhVucName" : "V\u0103n h\u00F3a" , "CqThName" : "C\u1EE5c B\u1EA3n quy\u1EC1n t\u00E1c gi\u1EA3" , "IsNew" : false , "Id" : 5 },{ "STT" : "10" , "Name" : "Th\u1EE7 t\u1EE5c c\u1EA5p gi\u1EA5y Ch\u1EE9ng nh\u1EADn \u0111\u0103ng k\u00FD quy\u1EC1n li\u00EAn quan cho c\u00E1 nh\u00E2n, ph\u00E1p nh\u00E2n n\u01B0\u1EDBc ngo\u00E0i" , "LinhVucName" : "V\u0103n h\u00F3a" , "CqThName" : "C\u1EE5c B\u1EA3n quy\u1EC1n t\u00E1c gi\u1EA3" , "IsNew" : false , "Id" : 13 } ]
    }
}
