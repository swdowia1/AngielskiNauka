namespace AngUnitTest
{
    public class classFun
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leng">leng znków</param>
        /// <param name="guid">+ 6 losowych znków</param>
        /// <returns></returns>
        public static string GetTextRandom(int leng = 10, bool guid = false)
        {
            string result = "".PadRight(leng, 'x');
            if (guid)
            {
                string g = Guid.NewGuid().ToString().Substring(0, 6).Replace("-", "");
                result += g;
            }
            return result;
        }
        public static string GetTextRandom()
        {
            return GetTextRandom(4, true);
        }
    }
}
