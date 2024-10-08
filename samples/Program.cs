using OkoloIt.Utilities.Logging.Samples;

WriterSample sample;

#if CONSOLE_MODE
sample = new WriteToConsoleSample();
#elif CUSTOM_MODE
sample = new WriteToCustomMethodSample();
#elif FILE_MODE
sample = new WriteToFileSample();
#elif SYSTEM_MODE
sample = new WriteToSystemTraceSample();
#else
sample = new UseDependencyInjection();
#endif

sample.InitializationLogger();
sample.Work();

Console.ReadLine();
