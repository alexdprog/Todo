using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using TodoApp.Models;

namespace TodoApp.DataAccess
{
        /// <summary>
        /// Сохранение данных
        /// </summary>
        public class TodoAppBaseContext : DbContext
        {
            public DbSet<Todo> Todo { get; set; }
            
            public TodoAppBaseContext()
            {
                Database.EnsureCreated();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="options"></param>
            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                string dbFileName = "TodoAppData.db";
                #if ANDROID
                var dbPath = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DataDirectory.Name).Path;
                #else
                var dbPath = FileSystem.AppDataDirectory;
                #endif
                dbFileName = Path.Combine(dbPath, dbFileName);
                options.UseSqlite($"Filename={dbFileName}");
                base.OnConfiguring(options);
            }
        }
        
        public class DbTodo
        {
            public int DbTodoId { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
            public string Notes { get; set; }
            public string Time { get; set; }
            public string Done { get; set; }
        }
        }
