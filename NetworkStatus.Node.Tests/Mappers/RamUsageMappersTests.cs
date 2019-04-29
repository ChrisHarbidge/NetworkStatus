using NetworkStatus.Node.Exceptions;
using NetworkStatus.Node.Mappers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NetworkStatus.Node.Tests.Mappers
{
    class RamUsageMappersTests
    {
        private RamUsageMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _mapper = new RamUsageMapper();
        }

        [Test]
        public void MapperMapsCorrectly()
        {
            var input = @"MemTotal:       16676536 kB
                        MemFree:        12596508 kB
                        Buffers:           34032 kB
                        Cached:           188576 kB
                        SwapCached:            0 kB
                        Active:           167556 kB
                        Inactive:         157876 kB
                        Active(anon):     103104 kB
                        Inactive(anon):    17440 kB
                        Active(file):      64452 kB
                        Inactive(file):   140436 kB
                        Unevictable:           0 kB
                        Mlocked:               0 kB
                        SwapTotal:      29198944 kB
                        SwapFree:       29198944 kB
                        Dirty:                 0 kB
                        Writeback:             0 kB
                        AnonPages:        102824 kB
                        Mapped:            71404 kB
                        Shmem:             17720 kB
                        Slab:              13868 kB
                        SReclaimable:       6744 kB
                        SUnreclaim:         7124 kB
                        KernelStack:        2848 kB
                        PageTables:         2524 kB
                        NFS_Unstable:          0 kB
                        Bounce:                0 kB
                        WritebackTmp:          0 kB
                        CommitLimit:      515524 kB
                        Committed_AS:    3450064 kB
                        VmallocTotal:     122880 kB
                        VmallocUsed:       21296 kB
                        VmallocChunk:      66044 kB
                        HardwareCorrupted:     0 kB
                        AnonHugePages:      2048 kB
                        HugePages_Total:       0
                        HugePages_Free:        0
                        HugePages_Rsvd:        0
                        HugePages_Surp:        0
                        Hugepagesize:       2048 kB
                        DirectMap4k:       12280 kB
                        DirectMap4M:      897024 kB";

            var inputLines = input.Split("\r\n").ToList();

            var ramUsage = _mapper.Map(inputLines);

            Assert.GreaterOrEqual(ramUsage.Free, 0);
            Assert.GreaterOrEqual(ramUsage.Total, 0);
        }

        [Test]
        public void MapperThrowsOnEmptyInput()
        {
            var inputLines = new List<string>();

            Assert.Throws<RamUsageReadingException>(() => _mapper.Map(inputLines));
        }

        [Test]
        public void MapperThrowsOnNullInput()
        {
            Assert.Throws<RamUsageReadingException>(() => _mapper.Map(null));
        }

        [Test]
        public void MapperThrowsWhenMissingLines()
        {
            var input = @"
                        Buffers:           34032 kB
                        Cached:           188576 kB
                        SwapCached:            0 kB
                        Active:           167556 kB
                        Inactive:         157876 kB
                        Active(anon):     103104 kB
                        Inactive(anon):    17440 kB
                        Active(file):      64452 kB
                        Inactive(file):   140436 kB
                        Unevictable:           0 kB
                        Mlocked:               0 kB
                        SwapTotal:      29198944 kB
                        SwapFree:       29198944 kB
                        Dirty:                 0 kB
                        Writeback:             0 kB
                        AnonPages:        102824 kB
                        Mapped:            71404 kB
                        Shmem:             17720 kB
                        Slab:              13868 kB
                        SReclaimable:       6744 kB
                        SUnreclaim:         7124 kB
                        KernelStack:        2848 kB
                        PageTables:         2524 kB
                        NFS_Unstable:          0 kB
                        Bounce:                0 kB
                        WritebackTmp:          0 kB
                        CommitLimit:      515524 kB
                        Committed_AS:    3450064 kB
                        VmallocTotal:     122880 kB
                        VmallocUsed:       21296 kB
                        VmallocChunk:      66044 kB
                        HardwareCorrupted:     0 kB
                        AnonHugePages:      2048 kB
                        HugePages_Total:       0
                        HugePages_Free:        0
                        HugePages_Rsvd:        0
                        HugePages_Surp:        0
                        Hugepagesize:       2048 kB
                        DirectMap4k:       12280 kB
                        DirectMap4M:      897024 kB";

            var inputLines = input.Split("\r\n").ToList();

            Assert.Throws<RamUsageReadingException>(() => _mapper.Map(inputLines));
        }
    }
}
