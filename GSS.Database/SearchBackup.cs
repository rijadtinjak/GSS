using System;

namespace GSS.Database
{
    public class SearchBackup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime DateModified { get; set; }
        public byte[] Backup { get; set; }
    }
}
