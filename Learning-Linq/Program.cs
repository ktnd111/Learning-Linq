using Learning_Linq.Data;
using Learning_Linq.Learning;
using Learning_Linq.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning_Linq;

internal class Program
{
    private static void Main()
    {
        using (var context = new LibraryContext())
        {
            context.Database.Migrate();

            // データが存在しない場合は初期データの挿入をスキップ
            if (!context.Authors.Any())
            {
                Console.WriteLine("データベースとテーブルが作成されました。データは未挿入です。");
            }
        }

        // LINQのサンプルを実行 その1
        var sample = new Linq1();
        sample.LearningLinq1();
    }
}