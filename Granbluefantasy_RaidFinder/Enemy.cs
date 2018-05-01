using System;
using System.Linq;

namespace Enemy.Model
{
    [Serializable]    
    [System.Xml.Serialization.XmlRoot("EnemyCollection")]
    public class EnemyCollection
    {        
        [System.Xml.Serialization.XmlArray("enemys")]
        [System.Xml.Serialization.XmlArrayItem("enemy", typeof(Enemy))]
        public Enemy[] Array { get; set; }
    }
    public class Enemy
    {
        [System.Xml.Serialization.XmlElement("name_ja")]
        public string Name_ja { get; set; }
        [System.Xml.Serialization.XmlElement("name_en")]
        public string Name_en { get; set; }
        [System.Xml.Serialization.XmlElement("level")]
        public string Level { get; set; }

        public string ID = "";
        public string Comment = "";

        //コンストラクタ
        public Enemy()
        {
            Name_ja = "";
            Name_en = "";
            Level = "";
            ID = "FFFFFFFF";
            Comment = "";
        }
    }

    class IndexFilter
    {
        //エネミーフィルタ
        public static Enemy Filtering(Enemy e, Enemy require, bool param)
        {
            if(param == true)
            {
                if(e.Name_ja == require.Name_ja && e.Level == require.Level)
                {
                    return e;
                }
                else
                {
                    return Tonull(e);
                }
            }
            else if (param == false)
            {
                if(e.Name_en == require.Name_en && e.Level == require.Level)
                {                    
                    e.Name_ja = require.Name_ja + " (Eng)";
                    return e;
                }
                else
                {
                    return Tonull(e);
                }
            }
            return null;
        }

        //イベントエネミーフィルタリング
        public static Enemy EventFiltering(Enemy e, EnemyCollection master, int index)
        {
            Enemy temp = new Enemy();

            //EventEnemy Lv.100
            if (index == master.Array.Count() + 2 && e.Level == "100")
            {
                for (int i = 0; master.Array.Count() > i; i++)
                {
                    if (e.Name_ja == master.Array[i].Name_ja || e.Name_en == master.Array[i].Name_en && e.Level == "100")
                    {
                        if (e.Name_ja != "")
                        {
                            if (e.Name_ja.StartsWith(master.Array[i].Name_ja.Substring(0, 2)) == true)
                            {
                                Tonull(e);
                                Tonull(temp);
                                break;
                            }
                        }
                        else if (e.Name_en != "")
                        {
                            if (e.Name_en.StartsWith(master.Array[i].Name_en.Substring(0, 4)) == true)
                            {
                                Tonull(e);
                                Tonull(temp);
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; master.Array.Count() > i; i++)
                {
                    if (e.Name_ja != master.Array[i].Name_ja || e.Name_en != master.Array[i].Name_en && e.Level == "100")
                    {
                        if (e.Name_ja == "")
                        {
                            e.Name_ja = e.Name_en;
                            e.Name_ja += " (Eng)";
                        }
                        return e;
                    }
                    else
                    {
                        e = temp;
                    }
                }
            }
            //EventEnemy Lv.60
            else if (index == master.Array.Count() + 1 && e.Level == "60")
            {
                for (int i = 0; master.Array.Count() > i; i++)
                {
                    if (e.Name_ja == master.Array[i].Name_ja || e.Name_en == master.Array[i].Name_en && e.Level == "60")
                    {
                        if (e.Name_ja != "")
                        {
                            if (e.Name_ja.StartsWith(master.Array[i].Name_ja.Substring(0, 2)) == true)
                            {
                                Tonull(e);
                                Tonull(temp);
                                break;
                            }
                        }
                        else if (e.Name_en != "")
                        {
                            if (e.Name_en.StartsWith(master.Array[i].Name_en.Substring(0, 4)) == true)
                            {
                                Tonull(e);
                                Tonull(temp);
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; master.Array.Count() > i; i++)
                {
                    if (e.Name_ja != master.Array[i].Name_ja || e.Name_en != master.Array[i].Name_en && e.Level == "60")
                    {
                        if (e.Name_ja == "")
                        {
                            e.Name_ja = e.Name_en;
                            e.Name_ja += " (Eng)";
                        }
                        return e;
                    }
                    else
                    {
                        e = temp;
                    }
                }
            }
            //EventEnemy Lv.50
            else if (index == master.Array.Count() && e.Level == "50")
            {
                for (int i = 0; master.Array.Count() > i; i++)
                {
                    if (e.Name_ja == master.Array[i].Name_ja || e.Name_en == master.Array[i].Name_en && e.Level == "100")
                    {
                        if (e.Name_ja != "")
                        {
                            if (e.Name_ja.StartsWith(master.Array[i].Name_ja.Substring(0, 2)) == true)
                            {
                                Tonull(e);
                                Tonull(temp);
                                break;
                            }
                        }
                        else if (e.Name_en != "")
                        {
                            if (e.Name_en.StartsWith(master.Array[i].Name_en.Substring(0, 4)) == true)
                            {
                                Tonull(e);
                                Tonull(temp);
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; master.Array.Count() > i; i++)
                {
                    if (e.Name_ja != master.Array[i].Name_ja || e.Name_en != master.Array[i].Name_en && e.Level == "100")
                    {
                        if (e.Name_ja == "")
                        {
                            e.Name_ja = e.Name_en;
                            e.Name_ja += " (Eng)";
                        }
                        return e;
                    }
                    else
                    {
                        e = temp;
                    }
                }
            }
            Tonull(e);
            return e;
        }

        //エネミー情報の破棄
        public static Enemy Tonull(Enemy e)
        {
            e.Name_ja = "undefined";
            e.ID = "FFFFFFF";
            e.Level = "999";
            return e;
        }        

        //表示要求Enemy変数の作成
        public static Enemy GenerateRequireEnemy(int index, EnemyCollection enemys)
        {
            Enemy e = new Enemy();

            e.Level = enemys.Array[index].Level;
            e.Name_ja = enemys.Array[index].Name_ja;
            e.Name_en = enemys.Array[index].Name_en;

            return e;
        }

    }
}
