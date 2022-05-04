using GitHubProjectSearcher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace GitHubProjectSearcher.Persistence.EntityTypeConfiguration
{
    //TODO: определится с размерами каждой ячейки, тк сейчас добавляется условно стринга, которая забирает много памяти
    //https://entityframeworkcore.com/knowledge-base/44829824/how-to-store-json-in-an-entity-field-with-ef-core- есть другой способ хранить данные
    public class QueryConfiguration : IEntityTypeConfiguration<Query>
    {
        public void Configure(EntityTypeBuilder<Query> builder)
        {
            builder.HasIndex(query => query.SearchString);

            builder.Property(query => query.Cards)
                .HasConversion
                (cards => JsonConvert.SerializeObject(cards, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                cards => JsonConvert.DeserializeObject<IList<Card>>(cards, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

        }
    }
}
