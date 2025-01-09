using Learning_Linq.Data;
using Learning_Linq.Learning;
using Microsoft.EntityFrameworkCore;

namespace Learning_Linq;

internal class Program
{
    private static void Main()
    {
        // データベースセットアップ
        SetupDatabase();

        // LINQのサンプルを実行
        RunLinqSamples();
    }

    private static void SetupDatabase()
    {
        using (var context = new LibraryContext())
        {
            // データベースが存在しなければ作成します
            if (!context.Database.CanConnect())
            {
                // データベースがない場合はマイグレーションを適用して作成
                Console.WriteLine("データベースが存在しないため、新規作成します...");
                context.Database.Migrate();
                Console.WriteLine("データベースとテーブルが作成されました。");

                // Insert.sql を実行
                ExecuteSqlFromFile(context, "Sql/Insert.sql");
                Console.WriteLine("初期データが挿入されました。");
            }
        }
    }
    private static void ExecuteSqlFromFile(LibraryContext context, string filePath)
    {
        try
        {
            // SQLファイルを読み込み
            string sql = File.ReadAllText(filePath);

            // SQLをデータベースに実行
            context.Database.ExecuteSqlRaw(sql);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"SQLファイルの実行中にエラーが発生しました: {ex.Message}");
        }
    }

    private static void RunLinqSamples()
    {
        // LINQのサンプルを実行
        var sample = new Linq1();
        sample.LearningLinq1();
    }
}