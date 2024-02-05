using OkoloIt.Utilities.Logging.Samples;

WriterSample sample;

#if CONSOLE_MODE
sample = new WriteToConsoleSample();
#elif CUSTOM_MODE
sample = new WriteToCustomMethodSample();
#elif FILE_MODE
sample = new WriteToFileSample();
#else
sample = new WriteToSystemTraceSample();
#endif

sample.InitializationLogger();
sample.Work();

Console.ReadLine();
