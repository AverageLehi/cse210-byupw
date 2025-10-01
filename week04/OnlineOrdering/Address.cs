class Address
{
    private string _city;
    private string _state;
    private string _country;
    public Address(string city, string state, string country)
    {
        _city = city;
        _state = state;
        _country = country;
    }
    public bool IsInUSA()
    {
        return _country.ToLower() == "usa" // check if country is USA
            || _country.ToLower() == "us" // check if country is US
            || _country.ToLower() == "united states"
            || _country.ToLower() == "united states of america"; // check if country is United States
    }
    public string GetFullAddress()
    { 
        return $"{_city}, {_state}, {_country}";
    }

}