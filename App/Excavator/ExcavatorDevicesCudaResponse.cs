using System.Collections.Generic;

#pragma warning disable CS8618

namespace NiceHashQuickMinerRichPresence.Excavator;

public class ExcavatorDevicesCudaResponse
{
    public List<Device> devices;
    public int id;
    public object? error;

    public class Details
    {
        public int cuda_id;
        public int sm_major;
        public int sm_minor;
        public int bus_id;
        public bool sli;
        public int bus_slot_id;
        public string pci_ident;
        public string ram_maker;
        public bool is_enterprise;
    }

    public class KernelTimes
    {
        public int avg;
        public int min;
        public int max;
        public int umed;
    }

    public class CoreUvolt
    {
        public int max_clock;
        public int max_mV;
    }

    public class Mt
    {
        public int? FAW;
        public int? RRD;
    }

    public class OcData
    {
        public int core_clock_delta;
        public int memory_clock_delta;
        public int power_limit_watts;
        public int power_limit_tdp;
        public int core_clock_limit;
        public List<CoreUvolt> core_uvolt;
        public List<List<int>> vfc;
        public Mt mt;
    }

    public class Fan
    {
        public int current_level;
        public int current_rpm;
        public int max_level;
        public int min_level;
        public bool is_auto;
        public int max_rpm;
    }

    public class Smartfan
    {
        public int mode;
        public int fixed_speed;
        public int target_gpu;
        public int target_vram;
        public int start_level;
        public int override_level_min;
        public int override_level_max;
        public int decrease_k;
        public int increase_k;
        public int increase_n_gpu;
        public int increase_n_vram;
    }

    public class OcLimits
    {
        public int core_delta_min;
        public int core_delta_max;
        public int vram_delta_min;
        public int vram_delta_max;
        public int tdp_min;
        public int tdp_max;
    }

    public class Timings
    {
        public int RC;
        public int RFC;
        public int RAS;
        public int RP;
        public int CFG0_R0;
        public int CL;
        public int WL;
        public int RD_RCD;
        public int WR_RCD;
        public int CFG1_R0;
        public int RPRE;
        public int WPRE;
        public int CDLR;
        public int WR;
        public int W2R_BUS;
        public int R2W_BUS;
        public int PDEX;
        public int PDEN2PDEX;
        public int FAW;
        public int AOND;
        public int CCDL;
        public int CCDS;
        public int REFRESH_LO;
        public int REFRESH;
        public int RRD;
        public int DELAY0;
        public int CFG4_R0;
        public int ADR_MIN;
        public int CFG5_R0;
        public int WRCRC;
        public int CFG5_R1;
        public int OFFSET0;
        public int DELAY0_MSB;
        public int OFFSET1;
        public int OFFSET2;
        public int DELAY01;
    }

    public class GpuMemoryTimings
    {
        public bool bEditable;
        public Timings timings;
    }

    public class Lhr
    {
        public int type;
        public double intensity;
        public double unlock_ratio;
        public int locks_occured;
    }

    public class Device
    {
        public int device_id;
        public string name;
        public int gpgpu_type;
        public string subvendor;
        public Details details;
        public string uuid;
        public int intensity;
        public int hw_errors;
        public int hw_errors_success;
        public KernelTimes kernel_times;
        public int gpu_temp;
        public int gpu_load;
        public bool too_hot;
        public int gpu_load_memctrl;
        public double gpu_power_usage;
        public int gpu_power_mode;
        public double gpu_power_limit_current;
        public double gpu_power_limit_min;
        public double gpu_power_limit_max;
        public double gpu_power_limit_default;
        public double gpu_tdp_current;
        public int gpu_clock_core_max;
        public int gpu_clock_core;
        public int gpu_clock_memory;
        public int gpu_clock_memory_default;
        public int gpu_fan_speed;
        public int gpu_fan_speed_rpm;
        public long gpu_memory_free;
        public object gpu_memory_used;
        public OcData oc_data;
        public List<Fan> fans;
        public int __vram_temp;
        public int __hotspot_temp;
        public Smartfan smartfan;
        public OcLimits oc_limits;
        public int gpu_mvolt_core;
        public GpuMemoryTimings gpu_memory_timings;
        public bool optimize_locked;
        public Lhr lhr;
    }
}
