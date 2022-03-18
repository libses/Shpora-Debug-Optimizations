﻿using System.IO;
using BenchmarkDotNet.Attributes;
using ImageProcessing;

namespace DotTraceExamples.Benchmarks
{
	[MemoryDiagnoser]
	[SimpleJob(warmupCount: 3, targetCount: 3)]
	public class MeanShiftBenchmark
	{
		private RGBImage image;

		[GlobalSetup]
		public void Setup()
		{
			var fileName = @"TestImages\TestImage.jpg";
			using (var fileStream = File.OpenRead(fileName))
			{
				image = RGBImage.FromStream(fileStream);
			}
		}

		[Benchmark]
		public void MeanShift()
		{
			image.MeanShift();
		}
	}
}