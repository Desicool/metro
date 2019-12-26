using System;
using System.Collections.Generic;
using metro.Entities;

namespace metro
{
    public static class EntityFactory
    {
        public static List<Metro> metros = new List<Metro>
        {
            new Metro("line1","1号线",new List<Station>{
                new Station("1-0","上海火车站","line1",0),
                new Station("1-1","汉中路","line1",1),
                new Station("1-2","新闸路","line1",2),
                new Station("1-3","人民广场","line1",3),
                new Station("1-4","黄陂南路","line1",4),
                new Station("1-5","陕西南路","line1",5),
                new Station("1-6","常熟路","line1",6),
                new Station("1-7","衡山路","line1",7),
                new Station("1-8","徐家汇","line1",8),
                new Station("1-9","上海体育馆","line1",9),
                new Station("1-10","漕宝路","line1",10),
                new Station("1-11","上海南站","line1",11),
                new Station("1-12","锦江乐园","line1",12),
                new Station("1-13","莲花路","line1",13),
                new Station("1-14","外环路","line1",14),
                new Station("1-15","莘庄","line1",15)
            }),
            new Metro("line2","2号线",new List<Station>{
                new Station("2-0","广兰路","line2",0),
                new Station("2-1","金科路","line2",1),
                new Station("2-2","张江高科","line2",2),
                new Station("2-3","龙阳路","line2",3),
                new Station("2-4","世纪公园","line2",4),
                new Station("2-5","上海科技馆","line2",5),
                new Station("2-6","世纪大道","line2",6),
                new Station("2-7","东昌路","line2",7),
                new Station("2-8","陆家嘴","line2",8),
                new Station("2-9","南京东路","line2",9),
                new Station("2-10","人民广场","line2",10),
                new Station("2-11","南京西路","line2",11),
                new Station("2-12","静安寺","line2",12),
                new Station("2-13","江苏路","line2",13),
                new Station("2-14","中山公园","line2",14),
                new Station("2-15","娄山关路","line2",15),
                new Station("2-16","威宁路","line2",16),
                new Station("2-17","北新泾","line2",17),
                new Station("2-18","淞虹路","line2",18),
                new Station("2-19","虹桥二号航站楼","line2",19),
                new Station("2-20","虹桥火车站","line2",20),
                new Station("2-21","徐泾东","line2",21)
            }),
            new Metro("line3","3号线",new List<Station>{
                new Station("3-0","上海南站","line3",0),
                new Station("3-1","石龙路","line3",1),
                new Station("3-2","龙漕路","line3",2),
                new Station("3-3","漕溪路","line3",3),
                new Station("3-4","宜山路","line3",4),
                new Station("3-5","虹桥路","line3",5),
                new Station("3-6","延安西路","line3",6),
                new Station("3-7","中山公园","line3",7),
                new Station("3-8","金沙江路","line3",8),
                new Station("3-9","曹杨路","line3",9),
                new Station("3-10","镇坪路","line3",10),
                new Station("3-11","中潭路","line3",11),
                new Station("3-12","上海火车站","line3",12),
                new Station("3-13","宝山路","line3",13),
                new Station("3-14","东宝兴路","line3",14),
                new Station("3-15","虹口足球场","line3",15),
                new Station("3-16","赤峰路","line3",16),
                new Station("3-17","大柏树","line3",17),
                new Station("3-18","江湾镇","line3",18),
                new Station("3-19","殷高西路","line3",19),
                new Station("3-20","长江南路","line3",20),
                new Station("3-21","淞发路","line3",21),
                new Station("3-22","张华浜","line3",22),
                new Station("3-23","淞滨路","line3",23),
                new Station("3-24","水产路","line3",24),
                new Station("3-25","宝杨路","line3",25),
                new Station("3-26","友谊路","line3",26),
                new Station("3-27","铁力路","line3",27),
                new Station("3-28","江杨北路","line3",28)
            }),
            new Metro("line4","4号线",new List<Station>{
                new Station("4-0","宜山路","line4",0),
                new Station("4-1","上海体育馆","line4",1),
                new Station("4-2","上海体育场","line4",2),
                new Station("4-3","东安路","line4",3),
                new Station("4-4","大木桥路","line4",4),
                new Station("4-5","鲁班路","line4",5),
                new Station("4-6","西藏南路","line4",6),
                new Station("4-7","南浦大桥","line4",7),
                new Station("4-8","塘桥","line4",8),
                new Station("4-9","蓝村路","line4",9),
                new Station("4-10","浦电路","line4",10),
                new Station("4-11","世纪大道","line4",11),
                new Station("4-12","浦东大道","line4",12),
                new Station("4-13","杨树浦路","line4",13),
                new Station("4-14","大连路","line4",14),
                new Station("4-15","临平路","line4",15),
                new Station("4-16","海伦路","line4",16),
                new Station("4-17","宝山路","line4",17),
                new Station("4-18","上海火车","line4",18),
                new Station("4-19","中潭路","line4",19),
                new Station("4-20","镇坪路","line4",20),
                new Station("4-21","曹杨路","line4",21),
                new Station("4-22","金沙江路","line4",22),
                new Station("4-23","中山公园","line4",23),
                new Station("4-24","延安西路","line4",24),
                new Station("4-25","虹桥路","line4",25),
                new Station("4-26","宜山路","line4",26),
                new Station("4-27","上海体育馆","line4",27),
                new Station("4-28","宜山路","line4",28),
                new Station("4-29","上海体育馆","line4",29),
                new Station("4-30","上海体育场","line4",30),
                new Station("4-31","东安路","line4",31),
                new Station("4-32","大木桥路","line4",32),
                new Station("4-33","鲁班路","line4",33),
                new Station("4-34","西藏南路","line4",34),
                new Station("4-35","南浦大桥","line4",35),
                new Station("4-36","塘桥","line4",36),
                new Station("4-37","蓝村路","line4",37),
                new Station("4-38","浦电路","line4",38),
                new Station("4-39","世纪大道","line4",39),
                new Station("4-40","浦东大道","line4",40),
                new Station("4-41","杨树浦路","line4",41),
                new Station("4-42","大连路","line4",42),
                new Station("4-43","临平路","line4",43),
                new Station("4-44","海伦路","line4",44),
                new Station("4-45","宝山路","line4",45),
                new Station("4-46","上海火车","line4",46),
                new Station("4-47","中潭路","line4",47),
                new Station("4-48","镇坪路","line4",48),
                new Station("4-49","曹杨路","line4",49),
                new Station("4-50","金沙江路","line4",50),
                new Station("4-51","中山公园","line4",51),
                new Station("4-52","延安西路","line4",52)
            }),
            new Metro("line5","5号线",new List<Station>{
                new Station("5-0","莘庄","line5",0),
                new Station("5-1","春申路","line5",1),
                new Station("5-2","银都路","line5",2),
                new Station("5-3","颛桥","line5",3),
                new Station("5-4","北桥","line5",4),
                new Station("5-5","剑川路","line5",5),
                new Station("5-6","东川路","line5",6),
                new Station("5-7","江川路","line5",7),
                new Station("5-8","西渡","line5",8),
                new Station("5-9","萧塘","line5",9),
                new Station("5-10","奉浦大道","line5",10),
                new Station("5-11","环城东路","line5",11),
                new Station("5-12","望园路","line5",12),
                new Station("5-13","金海湖","line5",13),
                new Station("5-14","奉贤新城","line5",14)
            }),
            new Metro("line6","6号线",new List<Station>{
                new Station("6-0","东方体育中心","line6",0),
                new Station("6-1","灵岩南路","line6",1),
                new Station("6-2","上南路","line6",2),
                new Station("6-3","华夏西路","line6",3),
                new Station("6-4","高青路","line6",4),
                new Station("6-5","东明路","line6",5),
                new Station("6-6","高科西路","line6",6),
                new Station("6-7","临沂新村","line6",7),
                new Station("6-8","上海儿童医学中心","line6",8),
                new Station("6-9","蓝村路","line6",9),
                new Station("6-10","浦电路","line6",10),
                new Station("6-11","世纪大道","line6",11),
                new Station("6-12","源深体育中心","line6",12),
                new Station("6-13","民生路","line6",13),
                new Station("6-14","北洋泾路","line6",14),
                new Station("6-15","德平路","line6",15),
                new Station("6-16","云山路","line6",16),
                new Station("6-17","金桥路","line6",17),
                new Station("6-18","博兴路","line6",18),
                new Station("6-19","五莲路","line6",19),
                new Station("6-20","巨峰路","line6",20),
                new Station("6-21","东靖路","line6",21),
                new Station("6-22","五洲大道","line6",22),
                new Station("6-23","洲海路","line6",23),
                new Station("6-24","外高桥保税区南站","line6",24),
                new Station("6-25","航津路","line6",25),
                new Station("6-26","外高桥保税区北站","line6",26),
                new Station("6-27","港城路","line6",27)
            }),
            new Metro("line7","7号线",new List<Station>{
                new Station("7-0","美兰湖","line7",0),
                new Station("7-1","罗南新村","line7",1),
                new Station("7-2","潘广路","line7",2),
                new Station("7-3","刘行","line7",3),
                new Station("7-4","顾村公园","line7",4),
                new Station("7-5","祁华路","line7",5),
                new Station("7-6","上海大学","line7",6),
                new Station("7-7","南陈路","line7",7),
                new Station("7-8","上大路","line7",8),
                new Station("7-9","场中路","line7",9),
                new Station("7-10","大场镇","line7",10),
                new Station("7-11","行知路","line7",11),
                new Station("7-12","大华三路","line7",12),
                new Station("7-13","新村路","line7",13),
                new Station("7-14","岚皋路","line7",14),
                new Station("7-15","镇坪路","line7",15),
                new Station("7-16","长寿路","line7",16),
                new Station("7-17","昌平路","line7",17),
                new Station("7-18","静安寺","line7",18),
                new Station("7-19","常熟路","line7",19),
                new Station("7-20","肇嘉浜路","line7",20),
                new Station("7-21","东安路","line7",21),
                new Station("7-22","龙华中路","line7",22),
                new Station("7-23","后滩","line7",23),
                new Station("7-24","长清路","line7",24),
                new Station("7-25","耀华路","line7",25),
                new Station("7-26","云台路","line7",26),
                new Station("7-27","高科西路","line7",27),
                new Station("7-28","杨高南路","line7",28),
                new Station("7-29","锦绣路","line7",29),
                new Station("7-30","芳华路","line7",30),
                new Station("7-31","龙阳路","line7",31),
                new Station("7-32","花木路","line7",32)
            })/*,
            new Metro("line8","8号线",new List<Station>{

            }),
            new Metro("line9","9号线",new List<Station>{

            }),
            new Metro("line10","10号线",new List<Station>{

            }),*/
        };
    }
}
