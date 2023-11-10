using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml;

namespace RealERPLIB.Extensions
{
    public static class ASTUtility
    {
        public static string FilterString(string SourceString)
        {
            SourceString = SourceString.Trim();
            SourceString = SourceString.Replace("'", "''");
            //SourceString = SourceString.Replace(@"""", "");
            //SourceString = SourceString.Replace("%", "");
            //SourceString = SourceString.Replace("--", "");
            //SourceString = SourceString.Replace(";", "");
            //SourceString = SourceString.Replace("(", "");
            //SourceString = SourceString.Replace(")", "");
            //SourceString = SourceString.Replace("_", "");
            return SourceString;
        }

        public static string Left(string host, int index)
        {
            return host.Substring(0, index);
        }

        public static string Right(string host, int index)
        {
            return host.Substring(host.Length - index);
        }
        public static string ExprToValue(string cExpr)
        {
            string mExpr1 = cExpr.Trim().Replace(",", "");
            mExpr1 = mExpr1.Replace("/", " div ");
            XmlDocument xmlDoc = new XmlDocument();
            XPathNavigator xPathNavigator = xmlDoc.CreateNavigator();
            mExpr1 = xPathNavigator.Evaluate(mExpr1).ToString();
            return mExpr1;
        }

        public static double StrNagative(string Stname)
        {
            double rval = Convert.ToDouble(Stname.ToString().Replace("-", "").Trim());
            double valsign = (Stname.Trim().Substring(0, 1) == "-" ? -1.00 : 1.00);
            return (rval * valsign);
        }

        public static double StrPosOrNagative(string Stname)
        {
            if (Stname.Length == 0)
                return 0.00;
            double rval = Convert.ToDouble(Stname.ToString().Replace("-", "").Trim());
            double valsign = (Stname.Trim().Substring(0, 1) == "-" ? -1.00 : 1.00);
            return (rval * valsign);
        }

        public static string TransBN(double XX1, int Index)
        {
            Index = (Index == 0 ? 1 : Index);
            string[] X1 = new string[101];
            string[] Y1 = new string[6];
            string[] Z1 = new string[3];

            X1[0] = "শূন্য ";
            X1[1] = "এক ";
            X1[2] = "দুই ";
            X1[3] = "তিন ";
            X1[4] = "চার ";
            X1[5] = "পাঁচ ";
            X1[6] = "ছয় ";
            X1[7] = "সাত ";
            X1[8] = "আট ";
            X1[9] = "নয় ";
            X1[10] = "দশ ";
            X1[11] = "এগার ";
            X1[12] = "বার ";
            X1[13] = "তের ";
            X1[14] = "চৌদ্দ ";
            X1[15] = "পনের ";
            X1[16] = "ষোল ";
            X1[17] = "সতের ";
            X1[18] = "আঠার ";
            X1[19] = "ঊনিষ ";
            X1[20] = "বিশ ";
            X1[21] = "একুশ ";
            X1[22] = "বাইশ ";
            X1[23] = "তেইশ ";
            X1[24] = "চব্বিশ ";
            X1[25] = "পঁচিশ ";
            X1[26] = "ছাব্বিশ ";
            X1[27] = "সাতাশ ";
            X1[28] = "আটাশ ";
            X1[29] = "ঊনত্রিশ ";
            X1[30] = "ত্রিশ ";
            X1[31] = "একত্রিশ ";
            X1[32] = "বত্রিশ ";
            X1[33] = "তেত্রিশ ";
            X1[34] = "চৌত্রিশ ";
            X1[35] = "পঁয়ত্রিশ ";
            X1[36] = "ছত্রিশ ";
            X1[37] = "সাঁইত্রিশ ";
            X1[38] = "আটত্রিশ ";
            X1[39] = "ঊনচল্লিশ ";
            X1[40] = "চল্লিশ ";
            X1[41] = "একচল্লিশ ";
            X1[42] = "বিয়াল্লিশ ";
            X1[43] = "তেতাল্লিশ ";
            X1[44] = "চুয়াল্লিশ ";
            X1[45] = "পঁয়তাল্লিশ ";
            X1[46] = "ছেচল্লিশ ";
            X1[47] = "সাতচল্লিশ ";
            X1[48] = "আটচল্লিশ ";
            X1[49] = "ঊনপঞ্চাশ ";
            X1[50] = "পঞ্চাশ ";
            X1[51] = "একান্ন  ";
            X1[52] = "বায়ান্ন ";
            X1[53] = "তিপ্পান্ন  ";
            X1[54] = "চুয়ান্ন  ";
            X1[55] = "পঞ্চান্ন ";
            X1[56] = "ছাপ্পান্ন ";
            X1[57] = "সাতান্ন  ";
            X1[58] = "আটান্ন  ";
            X1[59] = "ঊনষাট ";
            X1[60] = "ষাট ";
            X1[61] = "একষট্টি ";
            X1[62] = "বাষট্টি ";
            X1[63] = "তেষট্টি ";
            X1[64] = "চৌষট্টি ";
            X1[65] = "পঁয়ষট্টি ";
            X1[66] = "ছেষট্টি ";
            X1[67] = "সাতষট্টি ";
            X1[68] = "আটষট্টি ";
            X1[69] = "ঊনসত্তর ";
            X1[70] = "সত্তর ";
            X1[71] = "একাত্তর ";
            X1[72] = "বাহাত্তর ";
            X1[73] = "তিয়াত্তর ";
            X1[74] = "চুয়াত্তর ";
            X1[75] = "পঁচাত্তর ";
            X1[76] = "ছিয়াত্তর ";
            X1[77] = "সাতাত্তর ";
            X1[78] = "আটাত্তর ";
            X1[79] = "ঊনআশি ";
            X1[80] = "আশি ";
            X1[81] = "একাশি ";
            X1[82] = "বিরাশি ";
            X1[83] = "তিরাশি ";
            X1[84] = "চুরাশি ";
            X1[85] = "পঁচাশি ";
            X1[86] = "ছিয়াশি ";
            X1[87] = "সাতাশি ";
            X1[88] = "আটাশি ";
            X1[89] = "ঊননব্বই ";
            X1[90] = "নব্বই ";
            X1[91] = "একানব্বই ";
            X1[92] = "বিরানব্বই ";
            X1[93] = "তিরানব্বই ";
            X1[94] = "চুরানব্বই ";
            X1[95] = "পঁচানব্বই ";
            X1[96] = "ছিয়ানব্বই ";
            X1[97] = "সাতানব্বই ";
            X1[98] = "আটানব্বই ";
            X1[99] = "নিরানব্বই ";

            for (int I1 = 1; I1 <= 99; I1++)
                X1[I1] = X1[I1];



            Y1[1] = "শত ";
            Y1[2] = " হাজার ";
            Y1[3] = (Index >= 3 ? "লাখ " : "লাখ ");
            Y1[4] = (Index >= 3 ? "কোটি " : "কোটি ");
            //Y1[5] = "Trillion ";
            Z1[1] = "বিয়োগ ";
            Z1[2] = "শূন্য ";
            long N_1 = System.Convert.ToInt64(Math.Floor(XX1));
            string N_2 = XX1.ToString();
            while (!(N_2.Length == 0))
            {
                if (N_2.Substring(0, 1) == ".")
                    break;
                N_2 = N_2.Substring(1);
            }
            N_2 = (N_2.Length == 0 ? " " : N_2);
            switch (Index)
            {
                case 1:
                case 3:
                    N_2 = ((N_2.Substring(0, 1) == ".") ? ((string)(N_2.Substring(1) + "00000")).Substring(0, 5) : "00000");
                    break;
                case 2:
                case 4:
                    N_2 = ((N_2.Substring(0, 1) == ".") ? ((string)(N_2.Substring(1) + "00000")).Substring(0, 2) : "00");
                    break;
            }
            string S_GN = (Math.Sign(N_1) == -1 ? Z1[1] : "");
            string Z1_ER = (N_1 == 0 ? Z1[2] : "");
            string N_O = Right("00000000000000000" + Math.Abs(N_1).ToString(), 17);
            string[] L = new string[100];
            switch (Index)
            {
                case 1:
                case 2:
                    L[0] = "";
                    L[1] = ((Convert.ToInt32(N_O.Substring(0, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(0, 1))] + Y1[1]);
                    L[2] = ((Convert.ToInt32(N_O.Substring(1, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(1, 2))] + Y1[4]);
                    L[3] = ((Convert.ToInt32(N_O.Substring(3, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(3, 2))] + Y1[3]);
                    L[4] = ((Convert.ToInt32(N_O.Substring(5, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(5, 2))] + Y1[2]);
                    L[5] = ((Convert.ToInt32(N_O.Substring(7, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(7, 1))] + Y1[1]);
                    L[6] = ((Convert.ToInt32(N_O.Substring(8, 2)) == 0) ? ((Convert.ToInt32(N_O.Substring(0, 10))) == 0 ? "" : Y1[4]) : X1[Int32.Parse(N_O.Substring(8, 2))] + Y1[4]);
                    L[7] = ((Convert.ToInt32(N_O.Substring(10, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(10, 2))] + Y1[3]);
                    L[8] = ((Convert.ToInt32(N_O.Substring(12, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(12, 2))] + Y1[2]);
                    L[9] = ((Convert.ToInt32(N_O.Substring(14, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(14, 1))] + Y1[1]);
                    L[10] = (Convert.ToInt32(N_O.Substring(15, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(15, 2))];
                    break;
                case 3:
                case 4:
                    L[0] = ((Convert.ToInt32(N_O.Substring(0, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(0, 2))] + Y1[2]);
                    L[1] = ((Convert.ToInt32(N_O.Substring(2, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(2, 1))] + Y1[1]);
                    L[2] = ((Convert.ToInt32(N_O.Substring(3, 2)) == 0) ? ((Convert.ToInt32(N_O.Substring(2, 1)) == 0) ? "" : Y1[5]) : X1[Int32.Parse(N_O.Substring(3, 2))] + Y1[5]);
                    L[3] = ((Convert.ToInt32(N_O.Substring(5, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(5, 1))] + Y1[1]);
                    L[4] = ((Convert.ToInt32(N_O.Substring(6, 2)) == 0) ? ((Convert.ToInt32(N_O.Substring(5, 1)) == 0) ? "" : Y1[4]) : X1[Int32.Parse(N_O.Substring(6, 2))] + Y1[4]);
                    L[5] = ((Convert.ToInt32(N_O.Substring(8, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(8, 1))] + Y1[1]);
                    L[6] = ((Convert.ToInt32(N_O.Substring(9, 2)) == 0) ? ((Convert.ToInt32(N_O.Substring(8, 1)) == 0) ? "" : Y1[3]) : X1[Int32.Parse(N_O.Substring(9, 2))] + Y1[3]);
                    L[7] = ((Convert.ToInt32(N_O.Substring(11, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(11, 1))] + Y1[1]);
                    L[8] = ((Convert.ToInt32(N_O.Substring(12, 2)) == 0) ? ((Convert.ToInt32(N_O.Substring(11, 1)) == 0) ? "" : Y1[2]) : X1[Int32.Parse(N_O.Substring(12, 2))] + Y1[2]);
                    L[9] = ((Convert.ToInt32(N_O.Substring(14, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(14, 1))] + Y1[1]);
                    L[10] = (Convert.ToInt32(N_O.Substring(15, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(15, 2))];
                    break;
            }
            string O = S_GN + Z1_ER + L[0] + L[1] + L[2] + L[3] + L[4] + L[5] + L[6] + L[7] + L[8] + L[9] + L[10];
            string[] M = new string[100];
            string Q_ = "";
            string P = "";
            string R = "";
            switch (Index)
            {
                case 1:
                case 3:
                    M[1] = ((Convert.ToInt32(N_2) >= 1) ? X1[Int32.Parse(N_2.Substring(0, 1))] : "");
                    M[2] = ((Convert.ToInt32(N_2) >= 1 & Convert.ToInt32(N_2.Substring(1)) >= 1) ? X1[Int32.Parse(N_2.Substring(1, 1))] : "");
                    M[3] = ((Convert.ToInt32(N_2) >= 1 & Convert.ToInt32(N_2.Substring(2)) >= 1) ? X1[Int32.Parse(N_2.Substring(2, 1))] : "");
                    M[4] = ((Convert.ToInt32(N_2) >= 1 & Convert.ToInt32(N_2.Substring(3 - 1)) >= 1) ? X1[Int32.Parse(N_2.Substring(3, 1))] : "");
                    M[5] = ((Convert.ToInt32(N_2) >= 1 & Convert.ToInt32(N_2.Substring(4)) >= 1) ? X1[Convert.ToInt32(N_2.Substring(4, 1))] : "");
                    M[6] = ((Convert.ToInt32(N_2) > 0) ? "Point " : "");
                    P = M[6] + M[1] + M[2] + M[3] + M[4] + M[5];
                    //Q_ = O + P;
                    Q_ = "( Taka " + O + P + "Only )";
                    break;
                case 2:
                    M[1] = ((Convert.ToInt32(N_2) >= 1) ? X1[Int32.Parse(N_2)] : "");
                    M[6] = ((Convert.ToInt32(N_2) > 0) ? " পয়সা " : "");
                    // P = M[6] + M[1];
                    P = M[1] + M[6];
                    R = (O.Length) > 0 ? " টাকা " : "";
                    Q_ = "(" + O + R + " " + P + " মাত্র )";
                    break;

            }
            return Q_;
        }

        public static string Trans(double XX1, int Index)
        {
            Index = (Index == 0 ? 1 : Index);
            string[] X1 = new string[101];
            string[] Y1 = new string[6];
            string[] Z1 = new string[3];

            X1[0] = "Zero ";
            X1[1] = "One ";
            X1[2] = "Two ";
            X1[3] = "Three ";
            X1[4] = "Four ";
            X1[5] = "Five ";
            X1[6] = "Six ";
            X1[7] = "Seven ";
            X1[8] = "Eight ";
            X1[9] = "Nine ";
            X1[10] = "Ten ";
            X1[11] = "Eleven ";
            X1[12] = "Twelve ";
            X1[13] = "Thirteen ";
            X1[14] = "Fourteen ";
            X1[15] = "Fifteen ";
            X1[16] = "Sixteen ";
            X1[17] = "Seventeen ";
            X1[18] = "Eighteen ";
            X1[19] = "Nineteen ";
            X1[20] = "Twenty ";
            X1[30] = "Thirty ";
            X1[40] = "Forty ";
            X1[50] = "Fifty ";
            X1[60] = "Sixty ";
            X1[70] = "Seventy ";
            X1[80] = "Eighty ";
            X1[90] = "Ninety ";

            for (int J1 = 20; J1 <= 90; J1 = J1 + 10)
                for (int I1 = 1; I1 <= 9; I1++)
                    X1[J1 + I1] = X1[J1] + X1[I1];

            Y1[1] = "Hundred ";
            Y1[2] = "Thousand ";
            Y1[3] = (Index >= 3 ? "Million " : "Lac ");
            Y1[4] = (Index >= 3 ? "Billion " : "Crore ");
            Y1[5] = "Trillion ";
            Z1[1] = "Minnus ";
            Z1[2] = "Zero ";
            long N_1 = System.Convert.ToInt64(Math.Floor(XX1));
            string N_2 = XX1.ToString();
            while (!(N_2.Length == 0))
            {
                if (N_2.Substring(0, 1) == ".")
                    break;
                N_2 = N_2.Substring(1);
            }
            N_2 = (N_2.Length == 0 ? " " : N_2);
            switch (Index)
            {
                case 1:
                case 3:
                    N_2 = ((N_2.Substring(0, 1) == ".") ? ((string)(N_2.Substring(1) + "00000")).Substring(0, 5) : "00000");
                    break;
                case 2:
                case 4:
                    N_2 = ((N_2.Substring(0, 1) == ".") ? ((string)(N_2.Substring(1) + "00000")).Substring(0, 2) : "00");
                    break;
            }
            string S_GN = (Math.Sign(N_1) == -1 ? Z1[1] : "");
            string Z1_ER = (N_1 == 0 ? Z1[2] : "");
            string N_O = Right("00000000000000000" + Math.Abs(N_1).ToString(), 17);
            string[] L = new string[100];
            switch (Index)
            {
                case 1:
                case 2:
                    L[0] = "";
                    L[1] = ((Convert.ToInt32(N_O.Substring(0, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(0, 1))] + Y1[1]);
                    L[2] = ((Convert.ToInt32(N_O.Substring(1, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(1, 2))] + Y1[4]);
                    L[3] = ((Convert.ToInt32(N_O.Substring(3, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(3, 2))] + Y1[3]);
                    L[4] = ((Convert.ToInt32(N_O.Substring(5, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(5, 2))] + Y1[2]);
                    L[5] = ((Convert.ToInt32(N_O.Substring(7, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(7, 1))] + Y1[1]);
                    L[6] = ((Convert.ToInt32(N_O.Substring(8, 2)) == 0) ? ((Convert.ToInt32(N_O.Substring(0, 10))) == 0 ? "" : "") : X1[Int32.Parse(N_O.Substring(8, 2))] + Y1[4]);
                    L[7] = ((Convert.ToInt32(N_O.Substring(10, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(10, 2))] + Y1[3]);
                    L[8] = ((Convert.ToInt32(N_O.Substring(12, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(12, 2))] + Y1[2]);
                    L[9] = ((Convert.ToInt32(N_O.Substring(14, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(14, 1))] + Y1[1]);
                    L[10] = (Convert.ToInt32(N_O.Substring(15, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(15, 2))];
                    break;
                case 3:
                case 4:
                    L[0] = ((Convert.ToInt32(N_O.Substring(0, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(0, 2))] + Y1[2]);
                    L[1] = ((Convert.ToInt32(N_O.Substring(2, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(2, 1))] + Y1[1]);
                    L[2] = ((Convert.ToInt32(N_O.Substring(3, 2)) == 0) ? ((Convert.ToInt32(N_O.Substring(2, 1)) == 0) ? "" : Y1[5]) : X1[Int32.Parse(N_O.Substring(3, 2))] + Y1[5]);
                    L[3] = ((Convert.ToInt32(N_O.Substring(5, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(5, 1))] + Y1[1]);
                    L[4] = ((Convert.ToInt32(N_O.Substring(6, 2)) == 0) ? ((Convert.ToInt32(N_O.Substring(5, 1)) == 0) ? "" : Y1[4]) : X1[Int32.Parse(N_O.Substring(6, 2))] + Y1[4]);
                    L[5] = ((Convert.ToInt32(N_O.Substring(8, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(8, 1))] + Y1[1]);
                    L[6] = ((Convert.ToInt32(N_O.Substring(9, 2)) == 0) ? ((Convert.ToInt32(N_O.Substring(8, 1)) == 0) ? "" : Y1[3]) : X1[Int32.Parse(N_O.Substring(9, 2))] + Y1[3]);
                    L[7] = ((Convert.ToInt32(N_O.Substring(11, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(11, 1))] + Y1[1]);
                    L[8] = ((Convert.ToInt32(N_O.Substring(12, 2)) == 0) ? ((Convert.ToInt32(N_O.Substring(11, 1)) == 0) ? "" : Y1[2]) : X1[Int32.Parse(N_O.Substring(12, 2))] + Y1[2]);
                    L[9] = ((Convert.ToInt32(N_O.Substring(14, 1)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(14, 1))] + Y1[1]);
                    L[10] = (Convert.ToInt32(N_O.Substring(15, 2)) == 0) ? "" : X1[Int32.Parse(N_O.Substring(15, 2))];
                    break;
            }
            string O = S_GN + Z1_ER + L[0] + L[1] + L[2] + L[3] + L[4] + L[5] + L[6] + L[7] + L[8] + L[9] + L[10];
            string[] M = new string[100];
            string Q_ = "";
            string P = "";

            switch (Index)
            {
                case 1:
                case 3:
                    M[1] = ((Convert.ToInt32(N_2) >= 1) ? X1[Int32.Parse(N_2.Substring(0, 1))] : "");
                    M[2] = ((Convert.ToInt32(N_2) >= 1 & Convert.ToInt32(N_2.Substring(1)) >= 1) ? X1[Int32.Parse(N_2.Substring(1, 1))] : "");
                    M[3] = ((Convert.ToInt32(N_2) >= 1 & Convert.ToInt32(N_2.Substring(2)) >= 1) ? X1[Int32.Parse(N_2.Substring(2, 1))] : "");
                    M[4] = ((Convert.ToInt32(N_2) >= 1 & Convert.ToInt32(N_2.Substring(3 - 1)) >= 1) ? X1[Int32.Parse(N_2.Substring(3, 1))] : "");
                    M[5] = ((Convert.ToInt32(N_2) >= 1 & Convert.ToInt32(N_2.Substring(4)) >= 1) ? X1[Convert.ToInt32(N_2.Substring(4, 1))] : "");
                    M[6] = ((Convert.ToInt32(N_2) > 0) ? "Point " : "");
                    P = M[6] + M[1] + M[2] + M[3] + M[4] + M[5];
                    Q_ = O + P;
                    break;
                case 2:
                    M[1] = ((Convert.ToInt32(N_2) >= 1) ? X1[Int32.Parse(N_2)] : "");
                    M[6] = ((Convert.ToInt32(N_2) > 0) ? "And Paisa " : "");
                    P = M[6] + M[1];
                    //Q_ = "( Taka " + O + P + "Only )";
                    Q_ = O + P + "Taka Only";
                    break;
                case 4:
                    M[1] = ((Convert.ToInt32(N_2) >= 1) ? X1[Int32.Parse(N_2)] : "");
                    M[6] = ((Convert.ToInt32(N_2) > 0) ? "And Cent " : "");
                    P = M[6] + M[1];
                    //Q_ = "( Dollar " + O + P + "Only )";
                    Q_ = O + P + "Dollar Only";
                    break;
            }
            return Q_;
        }

        //--------------------------------------------------------------------------------------------------------
        public static string DefComa(double AA) // Bangla Coma
        {
            string[] A = new string[21];
            A[1] = ((Math.Sign(AA) >= 0) ? "" : "-");
            A[2] = Math.Abs(AA).ToString("###0.00");
            A[3] = Math.Abs(AA).ToString("###0.000");
            A[3] = ((double.Parse(A[3]) - (double.Parse(A[2])))).ToString();
            A[2] = A[2] + ((Double.Parse(A[3]) >= 0.005) ? 0.01 : 0);
            A[2] = Left(A[2], A[2].Length - 1);
            A[4] = ((string)(string.Empty.PadLeft(24) + A[2])).Substring(((string)(string.Empty.PadLeft(24) + A[2])).Length - 24);
            A[5] = A[4].Substring(0, 2);
            A[6] = A[4].Substring(2, 2);
            A[7] = A[4].Substring(4, 3);
            A[8] = A[4].Substring(7, 2);
            A[9] = A[4].Substring(9, 2);
            A[10] = A[4].Substring(11, 3);
            A[11] = A[4].Substring(14, 2);
            A[12] = A[4].Substring(16, 2);
            A[13] = A[4].Substring(18, 3);
            A[14] = A[5] + "," + A[6] + "," + A[7] + "," + A[8] + "," + A[9] + "," + A[10] + "," + A[11] + "," + A[12] + "," + A[13];
            A[14] = A[14].Trim();

            while (A[14].Substring(0, 1) == ",")
            {
                A[14] = A[14].Substring(1, A[14].Length - 1);
                A[14] = A[14].Trim();
            }
            A[15] = A[14] + A[4].Substring(21, 3);
            A[16] = ((string)(string.Empty.PadLeft(24) + A[15])).Substring(((string)(string.Empty.PadLeft(24) + A[15])).Length - 24) + " ";
            A[17] = ((A[1] != "") ? "(" : "") + A[16].Trim() + ((A[1] != "") ? ")" : "");
            return A[17];
        }

        //-------------------------------------------------------------------------------------------------------       

        public static string Concat(string compname, string username, string printdate)
        {
            string concat = "";
            concat = concat + "Printed from Computer Address:" + compname + ", User:" + username + ", Time:" + printdate;
            return concat;
        }

        public static string Cominformation()
        {
            return "Powered By: Pinovation Tech Ltd. www.pintechltd.com";

        }

        public static bool PagePermission(string frmname, DataSet ds)
        {
            frmname = frmname.Substring(frmname.LastIndexOf('/') + 1) + "";
            DataTable dt = ds.Tables[1];

            DataRow[] dr1 = dt.Select("(frmname+qrytype)='" + frmname + "'");
            return (dr1.Length > 0);
        }
        public static DataRow[] PagePermission1(string frmname, DataSet ds)
        {
            frmname = frmname.Substring(frmname.LastIndexOf('/') + 1) + "";
            DataTable dt = ds.Tables[1];
            DataRow[] dr1 = dt.Select("(frmname+qrytype)='" + frmname + "'");
            return dr1;
        }
        public static string ToRoman(int N)
        {
            const string Digits = "IVXLCDM";
            int I = 0;
            int Digit = 0;
            string Temp = null;
            string Temp1 = null;
            int N1 = 0;
            Temp1 = "";
            if (N >= 1000)
            {
                String s = "MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM";
                Temp1 = s.Substring(0, N1);
                N1 = N / (1000);
                N = N - N1 * 1000;
            }
            I = 1;
            Temp = "";
            while (N > 0)
            {
                Digit = N % 10;
                N = N / 10;
                switch (Digit)
                {
                    case 1:
                        Temp = Digits.Substring(I - 1, 1) + Temp;
                        break;
                    case 2:
                        Temp = Digits.Substring(I - 1, 1) + Digits.Substring(I - 1, 1) + Temp;
                        break;
                    case 3:
                        Temp = Digits.Substring(I - 1, 1) + Digits.Substring(I - 1, 1) + Digits.Substring(I - 1, 1) + Temp;
                        break;
                    case 4:
                        Temp = Digits.Substring(I - 1, 2) + Temp;
                        break;
                    case 5:
                        Temp = Digits.Substring(I, 1) + Temp;
                        break;
                    case 6:
                        Temp = Digits.Substring(I, 1) + Digits.Substring(I - 1, 1) + Temp;
                        break;
                    case 7:
                        Temp = Digits.Substring(I, 1) + Digits.Substring(I - 1, 1) + Digits.Substring(I - 1, 1) + Temp;
                        break;
                    case 8:
                        Temp = Digits.Substring(I, 1) + Digits.Substring(I - 1, 1) + Digits.Substring(I - 1, 1) + Digits.Substring(I - 1, 1) + Temp;
                        break;
                    case 9:
                        Temp = Digits.Substring(I - 1, 1) + Digits.Substring(I + 2 - 1, 1) + Temp;
                        break;
                }
                I = I + 2;
            }
            return Temp1 + Temp;


        }


        //Code Data export from  Gridview to exel
        //Response.Clear();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition","attachment;filename=DataTable.xls");
        //Response.Charset = "";
        //Response.ContentType = "application/vnd.ms-excel";

        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);

        //for (int i = 0; i < GridView1.Rows.Count; i++)
        //{
        //    //Apply text style to each Row
        //    GridView1.Rows[i].Attributes.Add("class", "textmode");

        //}
        //GridView1.RenderControl(hw);

        ////style to format numbers to string

        //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        //Response.Write(style);

        //Response.Output.Write(sw.ToString());
        //Response.Flush();            
        //Response.End();          


        public static string EncodePassword(string originalPassword)
        {

            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }


        public static int Datediff(DateTime dtto, DateTime dtfrm)
        {

            int year, mon, day;
            year = dtto.Year - dtfrm.Year;
            mon = dtto.Month - dtfrm.Month;
            day = dtto.Day - dtfrm.Day;
            if (day < 0)
            {

                day = day + 30;
                mon = mon - 1;
                if (mon < 0)
                {
                    mon = mon + 12;
                    year = year - 1;
                }
            }

            if (mon < 0)
            {

                mon = mon + 12;
                year = year - 1;
            }

            mon = year * 12 + mon;

            return mon;

        }

        public static int DatediffYear(DateTime dtto, DateTime dtfrm)
        {

            int year, mon, day;
            year = dtto.Year - dtfrm.Year;
            mon = dtto.Month - dtfrm.Month;
            day = dtto.Day - dtfrm.Day;
            if (day < 0)
            {

                day = day + 30;
                mon = mon - 1;
                if (mon < 0)
                {
                    mon = mon + 12;
                    year = year - 1;
                }
            }

            if (mon < 0)
            {

                mon = mon + 12;
                year = year - 1;
            }

            return year;

        }

        public static int Datediffday(DateTime dtto, DateTime dtfrm)
        {

            int year, mon, day, today;
            year = dtto.Year - dtfrm.Year;
            mon = dtto.Month - dtfrm.Month;
            day = dtto.Day - dtfrm.Day;
            if (day < 0)
            {

                day = day + 30;
                mon = mon - 1;
                if (mon < 0)
                {
                    mon = mon + 12;
                    year = year - 1;
                }
            }

            if (mon < 0)
            {

                mon = mon + 12;
                year = year - 1;
            }

            today = year * 365 + mon * 30 + day;
            return today;
        }

        public static string DateInVal(string date)
        {
            //string dateval = "";

            if (date.Length == 6)
                return (date.Substring(0, 2) + "." + date.Substring(2, 2) + "." + "20" + Right(date, 2));
            else if (date.Contains("."))
                return (date);
            else if (date.Length == 0)
                return "";
            else
                return (date.Substring(0, 2) + "." + date.Substring(2, 2) + "." + Right(date, 4));



        }
        public static string DateFormat(string date)

        {

            int index1 = date.IndexOf(".");
            return ((!date.Contains(".")) ? date : (date.Substring(index1 + 1, 2).Replace(".", "") + "." + date.Substring(0, index1) + "." + Right(date, 4)));
        }

        public static int RandNumber(int min, int max)
        {
            Random rnumber = new Random();
            return (rnumber.Next(min, max));

        }

    }
}
