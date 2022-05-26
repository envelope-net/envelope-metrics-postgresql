using Envelope.Data;
using Envelope.Database.PostgreSql;
using NpgsqlTypes;

namespace Envelope.Metrics.PostgreSql;

public class DBEventCounterDataWriterOptions : DbBatchWriterOptions, IBatchWriterOptions
{
	public DBEventCounterDataWriterOptions()
	{
		TableName = nameof(DbEventCounterData);

		PropertyNames = new List<string>
		{
			nameof(DbEventCounterData.IdEventCounter),
			nameof(DbEventCounterData.RuntimeUniqueKey),
			nameof(DbEventCounterData.CreatedUtc),
			nameof(DbEventCounterData.Increment),
			nameof(DbEventCounterData.Mean),
			nameof(DbEventCounterData.Count),
			nameof(DbEventCounterData.Min),
			nameof(DbEventCounterData.Max)
		};

		PropertyTypeMapping = new Dictionary<string, NpgsqlDbType>
		{
			{ nameof(DbEventCounterData.IdEventCounter), NpgsqlDbType.Uuid },
			{ nameof(DbEventCounterData.RuntimeUniqueKey), NpgsqlDbType.Uuid },
			{ nameof(DbEventCounterData.CreatedUtc), NpgsqlDbType.TimestampTz },
			{ nameof(DbEventCounterData.Increment), NpgsqlDbType.Double },
			{ nameof(DbEventCounterData.Mean), NpgsqlDbType.Double },
			{ nameof(DbEventCounterData.Count), NpgsqlDbType.Integer },
			{ nameof(DbEventCounterData.Min), NpgsqlDbType.Double },
			{ nameof(DbEventCounterData.Max), NpgsqlDbType.Double }
		};
	}
}
