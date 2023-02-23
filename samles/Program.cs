using OkoloIt.Utilities.Logging.Samples;

WriterSample sample = new WriteToConsoleSample();
sample.InitializationLogger();
sample.Work();

sample = new WriteToCustomMethodSample();
sample.InitializationLogger();
sample.Work();

sample = new WriteToFileSample();
sample.InitializationLogger();
sample.Work();

sample = new WriteToSystemTraceSample();
sample.InitializationLogger();
sample.Work();

Console.ReadLine();