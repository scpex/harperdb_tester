using System;

namespace harpertest
{
    class RunTests
    {
        public static void Main(string[] args)
        {

            //TestConnect tc = new TestConnect();
            //tc.Connect().Wait();

            //TestSchema ts = new TestSchema();
            //ts.AddSchema().Wait(); 

            //TestJsonDocs tjd = new TestJsonDocs();
            //tjd.CreateSchemaAndTable().Wait();
            //tjd.AddSimpleJson().Wait();
            //tjd.DropSchemaAndTable().Wait();
           
            //TestSchema tsm = new TestSchema();
            //tsm.CreateSchemaAndTable().Wait();
            //tsm.DropSchemaAndTable().Wait();

            //CRUD_test crud = new CRUD_test();
            //crud.Insert_test().Wait();
            //crud.Update_test().Wait();
            //crud.Delete_test().Wait();
            //crud.Search_test().Wait();
            
            //Describe des = new Describe();
            //des.Describe_all().Wait();
            //des.Describe_schema().Wait();

            //SQL_Test sql = new SQL_Test();
            //sql.create_table_customers().Wait();
            //sql.import_csvdata_customers().Wait();
            //sql.select_data_customers().Wait();
            //sql.drop_table_customers().Wait();
            
            SQL_Test2 sql = new SQL_Test2();
            for(int i=0;i<20;i++)
            {
                Console.Write("{0} ",i+1);
                sql.sql("select * from thailand.subdistrict");
            }
            //sql.sql("select lat+long as rs from thailand.subdistrict where ch_id=36 and ta_id=360302").Wait();
            Console.WriteLine("End of Query...");
            Console.ReadKey();
        }
    }
}