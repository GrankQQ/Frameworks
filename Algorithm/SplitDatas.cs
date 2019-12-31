using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class SplitDatas
    {
        List<Drug> drugs = new List<Drug>()
        {
            new Drug(){ Name = "*化学药品制剂*沙美特罗", Price = 383 },
            new Drug(){ Name = "**化学药品制剂*苏黄止咳胶囊", Price = 100 },
            new Drug(){ Name = "*动物胶*东阿阿胶", Price = 1229 },
            new Drug(){ Name = "*中成药*陈李济舒筋健腰丸 ", Price = 890 },
            new Drug(){ Name = "*中成药*片仔癀胶囊", Price = 428 },
            new Drug(){ Name = "*化学药品制剂*盐酸西那卡塞片", Price = 398 },
            new Drug(){ Name = "*动物胶*东阿阿胶", Price = 1229 },
            new Drug(){ Name = "*中成药*葛洪桂龙药膏", Price = 230 },
            new Drug(){ Name = "*中成药*安宫牛黄丸", Price = 1247 },
            new Drug(){ Name = "*化学药品制剂*舒洛地特软胶囊", Price = 125 },
            new Drug(){ Name = "*茶*丹参保心茶", Price = 585 },
            new Drug(){ Name = "*化学药品制剂*盐酸西那卡塞片 ", Price = 398 },
            new Drug(){ Name = "**中成药*益安宁丸 ", Price = 869 },
            new Drug(){ Name = "*中成药*九芝堂安宫牛黄丸", Price = 258 },
            new Drug(){ Name = "*中成药*陈李济舒筋健腰丸", Price = 890 },
            new Drug(){ Name = "*中成药*脑血疏口服液", Price = 280 },
            new Drug(){ Name = "*中成药*气血和胶囊", Price = 288 },
            new Drug(){ Name = "*中成药*舒筋健腰丸", Price = 890 },
            new Drug(){ Name = "*中成药*薏辛除湿止痛胶囊", Price = 569 },
            new Drug(){ Name = "*中成药*益安宁丸", Price = 865 },
            new Drug(){ Name = "*中成药*汇仁肾宝片", Price = 424 },
            new Drug(){ Name = "*中成药*二丁颗粒", Price = 39 },
            new Drug(){ Name = "*茶*丹参保心茶", Price = 585 },
            new Drug(){ Name = "*中成药*脑血疏口服液", Price = 280 },
            new Drug(){ Name = "*中成药*归脾颗粒", Price = 498 },
            new Drug(){ Name = "*中成药*补肺丸", Price = 298 },
            new Drug(){ Name = "*中成药*黄芪颗粒", Price = 298 },
            new Drug(){ Name = "*中成药*定坤丹水蜜丸", Price = 198 },
            new Drug(){ Name = "*中成药*复方阿胶浆", Price = 499 },
            new Drug(){ Name = "*化学药品制剂*盐酸西那卡塞片", Price = 405 },
            new Drug(){ Name = "*中成药*参莲胶囊", Price = 90 },
            new Drug(){ Name = "*中成药*二丁颗粒", Price = 39 },
            new Drug(){ Name = "*化学药品制剂*气血康口服液", Price = 97 },
            new Drug(){ Name = "*化学药品制剂*阿卡波糖片", Price = 90  },
            new Drug(){ Name = "*生物化学药品*头孢克洛干混悬剂", Price = 27  },
            new Drug(){ Name = "*化学药品制剂*诺和锐", Price = 75  },
            new Drug(){ Name = "*化学药品制剂*通心络胶囊", Price = 40  },
            new Drug(){ Name = "*中成药*夏枯草胶囊", Price = 60  },
            new Drug(){ Name = "*中成药*克感利咽口服液", Price = 51  },
            new Drug(){ Name = "*化学药品制剂*舒洛地特软胶囊", Price = 125  },
            new Drug(){ Name = "*化学药品制剂*利格列汀片", Price = 71  },
            new Drug(){ Name = "*中成药*益脑胶囊", Price = 99  },
            new Drug(){ Name = "*化学药品制剂*舒洛地特软胶囊", Price = 125  },
            new Drug(){ Name = "*化学药品制剂*双环醇片", Price = 75  },
            new Drug(){ Name = "*化学药品制剂*多烯磷脂酰胆碱胶囊", Price = 65  },
            new Drug(){ Name = "*中成药*三九感冒颗粒", Price = 15  },
            new Drug(){ Name = "*中成药*荨麻疹丸", Price = 70  },
            new Drug(){ Name = "*中成药*湿毒清胶囊", Price = 33  },
            new Drug(){ Name = "*化学药品制剂*盐酸吡格列酮片", Price = 35  },
            new Drug(){ Name = "*中成药*芪药消褐胶囊", Price =  76 },
            new Drug(){ Name = "*中成药*灯盏生脉胶囊", Price = 80  },
            new Drug(){ Name = "*化学药品制剂*速效救心丸", Price = 55  },
            new Drug(){ Name = "*化学药品制剂*蒲地蓝消炎片", Price = 20  },
            new Drug(){ Name = "*中成药*益安宁片", Price = 810  },
            new Drug(){ Name = "*化学药品制剂*银杏叶片", Price = 45  },
            new Drug(){ Name = "*中成药*复方银杏通脉口服液", Price = 70  },
            new Drug(){ Name = "*中成药*银丹心泰滴丸", Price = 46  },
            new Drug(){ Name = "*化学药品制剂*三九胃泰颗粒", Price = 20  },
            new Drug(){ Name = "*生物化学药品*头孢克洛干混悬剂", Price = 23  },
            new Drug(){ Name = "*化学药品制剂*严济堂归脾颗粒", Price =  249 },
            new Drug(){ Name = "*中成药*Soin五子衍宗软胶囊", Price = 498  },
            new Drug(){ Name = "*中成药*归脾颗粒 ", Price = 498  },
            new Drug(){ Name = "*化学药品制剂*薯蓣皂苷片", Price = 198  }
        };
    }

    

    public class Drug
    {
        /// <summary>
        /// 药品
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 个数
        /// </summary>
        public int Unit { get; set; }
    }
}
