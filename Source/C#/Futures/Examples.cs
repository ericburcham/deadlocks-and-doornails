﻿using System;
using System.Threading.Tasks;

using Resources;

namespace Futures
{
    public class Examples
    {
        public void Sequantial()
        {
            var a = Functions.Fibonacci(45);
            var b = Functions.Multiply(61, 109441);
            var result = Functions.GreatestCommonFactor(a, b);
            Console.WriteLine(result);
        }

        public void WithContinuation()
        {
            Task<int> futureA = Task.Factory.StartNew(() => Functions.Fibonacci(45));
            Task<int> futureB = Task.Factory.StartNew(() => Functions.Multiply(61, 109441));
            Task<int> futureResult = Task.Factory.ContinueWhenAll(
                new[] { futureA, futureB },
                tasks => Functions.GreatestCommonFactor(futureA.Result, futureB.Result));

            Console.WriteLine(futureResult.Result);
        }

        public void WithFutures()
        {
            Task<int> futureA = Task.Factory.StartNew(() => Functions.Fibonacci(45));
            Task<int> futureB = Task.Factory.StartNew(() => Functions.Multiply(61, 109441));
            var a = futureA.Result;
            var b = futureB.Result;
            var result = Functions.GreatestCommonFactor(a, b);
            Console.WriteLine(result);
        }
    }
}