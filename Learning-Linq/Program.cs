using Learning_Linq.Data;
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

            // LINQを使ってすべての著者を取得
            var allAuthors = context.Authors.Include(a => a.Books).ToList();
            Console.WriteLine("全ての著者とその本:");
            foreach (var author in allAuthors)
            {
                Console.WriteLine($"Author: {author.Name}");
                foreach (var book in author.Books)
                {
                    Console.WriteLine($"  Book: {book.Title}");
                }
            }

            // LINQで特定の著者を絞り込み
            Console.WriteLine("\n名前が 'George Orwell' の著者:");
            var georgeOrwell = context.Authors
                .Include(a => a.Books)
                .Where(a => a.Name == "George Orwell")
                .FirstOrDefault();
            if (georgeOrwell != null)
            {
                Console.WriteLine($"Author: {georgeOrwell.Name}");
                foreach (var book in georgeOrwell.Books)
                {
                    Console.WriteLine($"  Book: {book.Title}");
                }
            }

            // LINQで書籍タイトルに '1984' を含む書籍を取得
            Console.WriteLine("\nタイトルに '1984' を含む書籍:");
            var booksWith1984 = context.Books
                .Where(b => b.Title.Contains("1984"))
                .ToList();
            foreach (var book in booksWith1984)
            {
                Console.WriteLine($"Book: {book.Title}");
            }

            // LINQで著者が複数の本を持つものを取得
            Console.WriteLine("\n2冊以上の本を持つ著者:");
            var authorsWithMultipleBooks = context.Authors
                .Include(a => a.Books)
                .Where(a => a.Books.Count >= 2)
                .ToList();
            foreach (var author in authorsWithMultipleBooks)
            {
                Console.WriteLine($"Author: {author.Name}");
                foreach (var book in author.Books)
                {
                    Console.WriteLine($"  Book: {book.Title}");
                }
            }
        }
    }
}