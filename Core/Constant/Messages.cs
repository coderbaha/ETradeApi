namespace Core.Constant
{
    public static class Messages
    {
        public static string Added(string fieldname) => $"{fieldname} added succesfull";
        public static string Exist(string fieldname) => $"{fieldname} exist";
        public static string Listed(string fieldname) => $"{fieldname} listed succesfull";
        public static string NotListed(string fieldname) => $"{fieldname} not listed succesfull";
        public static string Updated(string fieldname) => $"{fieldname} updated succesfull";
        public static string Deleted(string fieldname) => $"{fieldname} deleted succesfull";
        public static string NotDeleted(string fieldname) => $"{fieldname} not deleted succesfull";
    }
}
