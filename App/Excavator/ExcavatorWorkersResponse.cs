using System.Collections.Generic;

namespace NiceHashQuickMinerRichPresence.Excavator;

#pragma warning disable CS8618

public sealed class ExcavatorWorkersResponse
{
    public List<Worker> workers;
    public List<int> share_times;
    public int id;
    public object? error;

    public class Avgspeed
    {
        public int window;
        public double speed;
    }

    public class Algorithm
    {
        public int id;
        public string name;
        public double speed;
        public List<Avgspeed> avgspeed;
    }

    public class Worker
    {
        public int worker_id;
        public int device_id;
        public string device_uuid;
        public List<object> @params;
        public string params_used;
        public List<Algorithm> algorithms;
    }
}
