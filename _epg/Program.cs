using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql;

namespace _epg
{
    struct wersja
    {
        string prefix;
        DateTime data;
    }
    class epg_data
    {
        long id;
        string start;
        string stop;
        string channel_id;
        bool deleted;
        string broadcast_date;
        int p_id;
        int content_id;
        string title;
        int category_nibble_lvl1;
        int category_nibble_lvl2;
        string category_type;
        string category_subtype;
        string language;
        int length;
        string episode_num;
        string original_title;
        string rating_system;
        string rating_value;
        string desc_short;
        string desc_medium;
        string desc_long;
        string version;

        public epg_data(long id, string start, string stop, string channel_id, bool deleted, string broadcast_date, int p_id, int content_id, string title,
        int category_nibble_lvl1, int category_nibble_lvl2, string category_type, string category_subtype, string language, int length, string episode_num,
        string original_title, string rating_system, string rating_value, string desc_short, string desc_medium, string desc_long, string version)
        {

            this.id = id;
            this.start = start;
            this.stop = stop;
            this.channel_id = channel_id;
            this.deleted = deleted;
            this.broadcast_date = broadcast_date;
            this.p_id = p_id;
            this.content_id = content_id;
            this.title = title;
            this.category_nibble_lvl1 = category_nibble_lvl1;
            this.category_nibble_lvl2 = category_nibble_lvl2;
            this.category_type = category_type;
            this.category_subtype = category_subtype;
            this.language = language;
            this.length = length;
            this.episode_num = episode_num;
            this.original_title = original_title;
            this.rating_system = rating_system;
            this.rating_value = rating_value;
            this.desc_short = desc_short;
            this.desc_medium = desc_medium;
            this.desc_long = desc_long;
            this.version = version;
        }
    }
        class Program
        {
            private MySqlConnection cn = new MySqlConnection("Server = tcms.aply.tv; Uid = internship; Password = tie6lav0chohph8Ahd9u; Database = epg_internship; Port = 3306");
            private MySqlCommand cmd = new MySqlCommand();
            List<epg_data> Lista = new List<epg_data>();

            Program() {}



            public List<epg_data> Listeczka()
            {
                String Query = "SELECT * FROM epg_data";

                cmd = new MySqlCommand(Query, cn);

                cn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    long id = (long)reader["id"];
                    string start = reader["start"].ToString();
                    string stop = reader["stop"].ToString();
                    string channel_id = reader["channel_id"].ToString();
                    bool deleted = (bool)reader["deleted"];
                    string broadcast_date = reader["broadcast_date"].ToString();
                    int p_id = (int)reader["p_id"];
                    int content_id = (int)reader["content_id"];
                    string title = reader["title"].ToString();
                    int category_nibble_lvl1 = (int)reader["category_nibble_lvl1"];
                    int category_nibble_lvl2 = (int)reader["category_nibble_lvl2"];
                    string category_type = reader["category_type"].ToString();
                    string category_subtype = reader["category_subtype"].ToString();
                    string language = reader["language"].ToString();
                    int length = (int)reader["length"];
                    string episode_num = reader["episode_num"].ToString();
                    string original_title = reader["original_title"].ToString();
                    string rating_system = reader["rating_system"].ToString();
                    string rating_value = reader["rating_value"].ToString();
                    string desc_short = reader["desc_short"].ToString();
                    string desc_medium = reader["desc_medium"].ToString();
                    string desc_long = reader["desc_long"].ToString();
                    string version = reader["version"].ToString();

                    epg_data obj = new epg_data(id, start, stop, channel_id, deleted, broadcast_date, p_id, content_id, title,
            category_nibble_lvl1, category_nibble_lvl2, category_type, category_subtype, language, length, episode_num,
            original_title, rating_system, rating_value, desc_short, desc_medium, desc_long, version);

                Lista.Add(obj);  
                }

                return Lista;
            }

            static void Main(string[] args)
            {
                Program Epg = new Program();
                Epg.Listeczka();

            }
        }
    
}
