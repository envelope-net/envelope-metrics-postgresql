namespace Envelope.Metrics.PostgreSql;

public interface IEventCounterDataWriter
{
	IReadOnlyDictionary<string, IEventListener> EventListeners { get; }

	void EnableAllEventListeners();
	void DisableWriteForAllEventListeners();
}
