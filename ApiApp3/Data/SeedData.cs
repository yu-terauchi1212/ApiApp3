using ApiApp3.Models;

namespace ApiApp3.Data
{
    public class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            // Articlesテーブルにデータが1件もない場合に実行
            if (!context.Study.Any())
            {
                // 新しいArticleデータを追加
                context.Study.Add(new Study
                {
                    Subject = "ダミータイトル１",
                    Categories = "本文です１",
                    Time = 3,
                    Date = "2025/06/16"
                });
                context.SaveChanges(); // データベースに保存
            }
        }
    }
}
