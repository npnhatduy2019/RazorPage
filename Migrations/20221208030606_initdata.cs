using System;
using RazorWeb.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using Bogus;

#nullable disable

namespace RazorWeb.Migrations
{
    /// <inheritdoc />
    public partial class initdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

                // migrationBuilder.InsertData("Articles",
                //                             new string[]{"Title","Description","DateCreate"},
                //                             new Object[]{"Test seed data","abc",DateTime.Now});
                // migrationBuilder.InsertData("Articles",
                //                             new string[]{"Title","Description","DateCreate"},
                //                             new Object[]{"Test seed data 1","abc",new DateTime(2022,11,25,0,0,0)});

                Randomizer.Seed = new Random(8675309);
                var seedArticle=new Faker<Article>();
                                                    // seedArticle.StrictMode(true);
                                                    seedArticle.RuleFor(o=>o.Title,f=>f.Lorem.Sentence(5,5));
                                                    seedArticle.RuleFor(o=>o.Description,f=>f.Lorem.Paragraphs(1,3));
                                                    seedArticle.RuleFor(o=>o.DateCreate,f=>f.Date.Between(new DateTime(2020,1,1,0,0,0),DateTime.Now));
            for(int i=0;i<150;i++)
            {
                var fdata = seedArticle.Generate();

                migrationBuilder.InsertData("Articles",
                                           columns: new string[]{"Title","Description","DateCreate"},
                                           values: new Object[]{fdata.Title,fdata.Description,fdata.DateCreate});
            }



        }


              

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
