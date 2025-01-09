using Learning_Linq.Data;
using Microsoft.EntityFrameworkCore;

namespace Learning_Linq.Learning;

public class Linq0
{
    public void LearningLinq0()
    {
        using (var context = new LibraryContext())
        {
            // データベースから著者とその書籍を取得
            var authorsWithBooks = context.Authors
                .Include(a => a.Books) // 著者に関連する書籍も取得
                .ToList();

            // 取得したデータをコンソールに表示
            foreach (var author in authorsWithBooks)
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