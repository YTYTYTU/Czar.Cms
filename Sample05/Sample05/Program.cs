using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace Sample05
{
    class Program
    {
        /// <summary>
        /// 泛型类
        /// </summary>
        /// <param name="args"></param>
        public class TestClass<T>
        {
            //定义一个长度为5的泛型类型的数组
            T[] obj = new T[5];
            int count = 0;
            //向泛型类型添加数据
            public void Add(T item)
            {
                if (count + 1 < 6)
                {
                    obj[count] = item;
                }
                count++;
            }
            //foreach语句迭代索引
            public T this[int index]
            {
                get { return obj[index]; }
                set { obj[index] = value; }
            }
        }
        /// <summary>
        /// 泛型方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void Swap<T>(ref T a, ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
            //test_insert();
            //test_mult_insert();
            //test_del();
            //test_mult_del();
            //test_update();
            //test_mult_update();
            //test_select_one();
            //test_select_list();
            //test_select_content_with_comment();
            //用整型来实例化泛型类
            //TestClass<int> intobj = new TestClass<int>();
            ////向集合中添加int数据
            //intobj.Add(1);
            //intobj.Add(2);
            //intobj.Add(3);         //没有装箱
            //intobj.Add(4);
            //intobj.Add(5);
            //intobj.Add(6);
            ////遍历显示数据
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(intobj[i]);//没有拆箱
            //}
            //int a = 40, b = 60;
            //Console.WriteLine("Bofore swap: {0},{1}",a,b);
            //Swap<int>(ref a, ref b);
            //Console.WriteLine("After swap:{0},{1}",a,b);
            //Dictionary<int, string> dobj = new Dictionary<int, string>(5);
            //dobj.Add(1,"Tom");
            //dobj.Add(2, "John");
            //dobj.Add(3, "Maria");
            //dobj.Add(4, "Max");
            //dobj.Add(5, "Ram");
            //for (int i = 1; i < dobj.Count; i++)
            //{
            //    Console.WriteLine(dobj[i]);
            //}
            ////定义一个字典集合
            //Dictionary<string, emp> dobj = new Dictionary<string, emp>(2);
            ////向字典中添加元素
            //emp tom = new emp("tom",2000);
            //dobj.Add("tom",tom);
            //emp john = new emp("john",4000);
            //dobj.Add("john", john);
            //foreach (object str in dobj.Values)
            //{
            //    Console.WriteLine(str);
            //}
            //Queue qObj = new Queue();
            //qObj.Enqueue("Tom");
            //qObj.Enqueue("Harry");
            //qObj.Enqueue("Maria");
            //qObj.Enqueue("john");
            //while (qObj.Count!=0)
            //{
            //    Console.WriteLine(qObj.Dequeue());
            //}
            //
            int[] iArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //定义一个堆栈
            Stack stack = new Stack(iArray);
            Console.WriteLine("Total items=" + stack.Count);
            //显示集合数据
            for (int i = 0; i < stack.Count; ++i)
            {
                Console.WriteLine(stack.Pop());
            }
            Console.ReadKey();
        }
        /// <summary>
        /// 测试插入单条数据
        /// </summary>
        static void test_insert()
        {
            var content = new Content
            {
                title = "标题1",
                content = "内容1",
            };
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=tkd123;Initial Catalog=text;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time)
                VALUES   (@title,@content,@status,@add_time)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_insert：插入了{result}条数据！");
            }
        }
        /// <summary>
        /// 测试一次批量插入俩条数据
        /// </summary>
        static void test_mult_insert()
        {
            List<Content> contents = new List<Content>()
            {
                new Content
                {
                     title = "批量插入标题1",
                content = "批量插入内容1",
                },
                new Content
                {
                     title = "批量插入标题2",
                content = "批量插入内容2",
                },
            };
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=tkd123;Initial Catalog=text;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time)
                VALUES   (@title,@content,@status,@add_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_insert：插入了{result}条数据！");
            }
        }
        /// <summary>
        /// 测试删除单条数据
        /// </summary>
        static void test_del()
        {
            var content = new Content { id = 2 };
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=tkd123;Initial Catalog=text;Pooling=true;Max Pool Size=100;"))
            {
                string sql_del = @"delete from [Content] where (id=@id)";
                var result = conn.Execute(sql_del, content);
                Console.WriteLine($"test_insert：删除了{result}条数据！");
            }
        }
        /// <summary>
        /// 测试一次批量删除两条数据
        /// </summary>
        static void test_mult_del()
        {
            List<Content> contents = new List<Content>()
            { new Content { id = 3 }, new Content { id = 4 } };
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=tkd123;Initial Catalog=text;Pooling=true;Max Pool Size=100;"))
            {
                string sql_del = @"delete from [Content] where (id=@id)";
                var result = conn.Execute(sql_del, contents);
                Console.WriteLine($"test_insert：删除了{result}条数据！");
            }
        }
        /// <summary>
        /// 测试修改单条数据
        /// </summary>
        static void test_update()
        {
            var content = new Content
            {
                id = 5,
                title = "标题5",
                content = "内容5",

            };
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=tkd123;Initial Catalog=text;Pooling=true;Max Pool Size=100;"))
            {
                string sql_del = @"UPDATE  [Content]
SET         title = @title, [content] = @content, modify_time = GETDATE()
WHERE   (id = @id)";
                var result = conn.Execute(sql_del, content);
                Console.WriteLine($"test_insert：修改了{result}条数据！");
            }
        }
        /// <summary>
        /// 测试一次批量修改多条数据
        /// </summary>
        static void test_mult_update()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                id=6,
                title = "批量修改标题6",
                content = "批量修改内容6",

            },
               new Content
            {
                id =7,
                title = "批量修改标题7",
                content = "批量修改内容7",

            },
        };
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=tkd123;Initial Catalog=text;Pooling=true;Max Pool Size=100;"))
            {
                string sql_del = @"UPDATE  [Content]
SET         title = @title, [content] = @content, modify_time = GETDATE()
WHERE   (id = @id)";
                var result = conn.Execute(sql_del, contents);
                Console.WriteLine($"test_insert：修改了{result}条数据！");
            }
        }
        /// <summary>
        /// 查询单条指定的数据
        /// </summary>
        static void test_select_one()
        {
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=tkd123;Initial Catalog=text;Pooling=true;Max Pool Size=100;"))
            {
                string sql_select = @"select * from [content] where id=@id";
                var result = conn.QueryFirstOrDefault<Content>(sql_select, new { id = 5 });
                Console.WriteLine($"test_select_one：查到的数据为：" + result);
            }
        }
        /// <summary>
        /// 查询多条指定的数据
        /// </summary>
        static void test_select_list()
        {
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=tkd123;Initial Catalog=text;Pooling=true;Max Pool Size=100;"))
            {
                string sql_select = @"select * from [dbo].[content] where id in @ids";
                var result = conn.Query<List<Content>>(sql_select, new { ids = new int[] { 6, 7 } });
                Console.WriteLine($"test_select_list：查到的数据为：" + result);
            }
        }
        /// <summary>
        /// 关联查询
        /// </summary>
        static void test_select_content_with_comment()
        {
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=tkd123;Initial Catalog=text;Pooling=true;Max Pool Size=100;"))
            {
                string sql_select = @"select * from content where id=@id select * from comment where content_id=@id;";
                using (var result = conn.QueryMultiple(sql_select, new { id = 5 }))
                {
                    var content = result.ReadFirstOrDefault<ContentWithComment>();
                    content.comments = result.Read<Comment>();

                    Console.WriteLine($"test_select_content_with_comment:内容5的评论数量{content.comments.Count()}");

                }
            }
        }
    }
}
