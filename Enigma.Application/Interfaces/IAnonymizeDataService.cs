namespace Enigma.Application.Interfaces
{
	public interface IAnonymizeDataService : IBasicService
	{
		string AnonymizeData(string jsonData, string productCode);

	}
}
