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
        public static Enemy EventFiltering(Enemy e, EnemyCollection master)
        {
            var temp = e;
            switch (e.Level)
            {
                case "50":
                    for (int i = 0; master.Array.Count() > i; i++)
                    {
                        if (e.Name_ja.StartsWith(master.Array[i].Name_ja) == false &&
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
                    for(int i = 0; master.Array.Count() > i; i++)
                    {
                        if(e.Name_ja.StartsWith(master.Array[i].Name_ja) == false &&
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
        public static Enemy GenerateRequireEnemy(int index, EnemyCollection enemys)
        {
            Enemy e = new Enemy();

            e.Level = enemys.Array[index].Level;
            e.Name_ja = enemys.Array[index].Name_ja;
            e.Name_en = enemys.Array[index].Name_en;

            return e;
        }    
        
        //言語判定
        public static bool CheckEnemyNameLanguage(string name, EnemyCollection enemys)
        {
            for (int i = 0; enemys.Array.Count() > i; i++)
            {
                if(enemys.Array[i].Name_ja == name)
                {
                    return true;
                    
                }
                else if(name == enemys.Array[i].Name_en)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
