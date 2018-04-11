using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granbluefantasy_RaidFinder
{
    public class Enemy
    {
        public string Name;
        public string Level;
        public string ID;

        //コンストラクタ
        public Enemy()
        {
            Name = "";
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
            string requireenemy = require.Name;
            switch (requirelevel)
            {
                case 50:
                    if (e.Level != "50" || e.Name.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 60:
                    if (e.Level != "60" || e.Name.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 70:
                    if (e.Level != "70" || e.Name.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 75:
                    if (e.Level != "75" || e.Name.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 90:
                    if (e.Level != "90" || e.Name.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 100:
                    if (e.Level != "100" || e.Name.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 110:
                    if (e.Level != "110" || e.Name.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 120:
                    if (e.Level != "120" || e.Name.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 150:
                    if (e.Level != "150" || e.Name.IndexOf(requireenemy) == -1)
                    {
                        Tonull(e);
                    }
                    break;
                case 200:
                    if (e.Level != "200" || e.Name.IndexOf(requireenemy) == -1)
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
                        if (e.Name.StartsWith(list[i].Substring(5, 2)) == false &&
                            e.Name.Contains("ティアマ") == false &&
                            e.Name.Contains("コロッサ") == false &&
                            e.Name.Contains("ユグドラ") == false &&
                            e.Name.Contains("リヴァイ") == false &&
                            e.Name.Contains("セレスト") == false &&
                            e.Name.Contains("アドウェ") == false)
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
                //case :
                default:
                    break;
            }
            Tonull(e);
            return e;
        }

        //ぬるぬる
        public static Enemy Tonull(Enemy e)
        {
            e.Name = "undefined";
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
                e.Name = enemys[index].Substring(5);
            }
            else
            {
                e.Name = enemys[index].Substring(4);
            }

            return e;
        }        
    }
}
