using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy.Model
{
    [System.Xml.Serialization.XmlRoot("enemys")]
    public class Enemys
    {
        [System.Xml.Serialization.XmlElement("enemys")]
        public Enemy Enemy { get; set; }
    }
    public class Enemy
    {
        [System.Xml.Serialization.XmlElement("name_ja")]
        public string Name_ja { get; set; }
        [System.Xml.Serialization.XmlElement("name_en")]
        public string Name_en { get; set; }
        [System.Xml.Serialization.XmlElement("level")]
        public string Level { get; set; }

        public string ID;

        //コンストラクタ
        public Enemy()
        {
            Name_ja = "";
            Name_en = "";
            Level = "";
            ID = "FFFFFFFF";
        }
    }

    class IndexFilter
    {
        //エネミーフィルタ
        //フィルタ方法要再考
        //できた
        public static Enemy Filtering(Enemy e, Enemy require)
        {
            int requirelevel = Convert.ToInt32(require.Level);
            string requireenemy = require.Name_ja;
            switch (requirelevel)
            {
                case 50:
                    if (e.Level != "50" || e.Name_ja.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 60:
                    if (e.Level != "60" || e.Name_ja.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 70:
                    if (e.Level != "70" || e.Name_ja.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 75:
                    if (e.Level != "75" || e.Name_ja.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 90:
                    if (e.Level != "90" || e.Name_ja.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 100:
                    if (e.Level != "100" || e.Name_ja.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 110:
                    if (e.Level != "110" || e.Name_ja.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 120:
                    if (e.Level != "120" || e.Name_ja.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 150:
                    if (e.Level != "150" || e.Name_ja.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 200:
                    if (e.Level != "200" || e.Name_ja.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;

                default:
                    break;
            }
            return e;
        }

        //イベントエネミーフィルタリング
        public static Enemy EventFiltering(Enemy e, string[] list)
        {
            var temp = e;
            switch (e.Level)
            {
                case "50":
                    for (int i = 0; list.Count() > i; i++)
                    {
                        if (e.Name_ja.StartsWith(list[i].Substring(5, 2)) == false &&
                            e.Name_ja.Contains("ティアマ") == false &&
                            e.Name_ja.Contains("コロッサ") == false &&
                            e.Name_ja.Contains("ユグドラ") == false &&
                            e.Name_ja.Contains("リヴァイ") == false &&
                            e.Name_ja.Contains("セレスト") == false &&
                            e.Name_ja.Contains("アドウェ") == false)
                        {
                            return e;
                        }
                        else
                        {
                            e = temp;
                        }
                    }
                    break;                
                case "60":
                    for(int i = 0; list.Count() > i; i++)
                    {
                        if(e.Name_ja.StartsWith(list[i].Substring(5, 2)) == false &&
                            e.Name_ja.Contains("リヴァイ") == false &&
                            e.Name_ja.Contains("ユグドラ") == false)
                        {
                            return e;
                        }
                        else
                        {
                            e = temp;
                        }
                    }
                    break;
                //イベントボスのレベル次第で追記
                //case "":
                default:
                    break;
            }
            Tonull(e);
            return e;
        }

        //ぬるぬる
        public static Enemy Tonull(Enemy e)
        {
            e.Name_ja = "undefined";
            e.ID = "FFFFFFF";
            e.Level = "999";
            return e;
        }        

        //表示要求Enemy変数の作成
        public static Enemy GenerateRequireEnemy(int index,string[] enemys)
        {
            Enemy e = new Enemy();

            e.Level = enemys[index].Substring(1, 2);
            if (Convert.ToInt32(e.Level) < 21)
            {
                e.Level += "0";
                e.Name_ja = enemys[index].Substring(5);
            }
            else
            {
                e.Name_ja = enemys[index].Substring(4);
            }

            return e;
        }        
    }
}
