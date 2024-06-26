﻿namespace BeyondNet.Aop.Tests
{
    public interface INumberProvider
    {
        int Get1(int seed);

        int Get2(int seed);

        int Get3(int seed);

        int Get4(int seed);

        int Get5(int seed, string id);

        int Get6(int seed, Parameter parameter);
    }
}
