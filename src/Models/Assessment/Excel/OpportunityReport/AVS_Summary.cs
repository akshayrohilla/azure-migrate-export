namespace Azure.Migrate.Export.Models
{
    public class AVS_Summary
    {
        public string SubscriptionId { get; set; }
        public string ResourceGroup { get; set; }
        public string ProjectName { get; set; }
        public string GroupName { get; set; }
        public string AssessmentName { get; set; }
        public string SizingCriterion { get; set; }
        public string AssessmentType { get; set; }
        public string CreatedOn { get; set; }
        public int TotalMachinesAssessed { get; set; }
        public int MachinesReady { get; set; }
        public int MachinesReadyWithConditions { get; set; }
        public int MachinesNotReady { get; set; }
        public int MachinesReadinessUnknown { get; set; }
        public int RecommendedNumberOfNodes { get; set; }
        public string NodeType { get; set; }
        public double MonthlyTotalCostEstimate { get; set; }
        public double PredictedCpuUtilizationPercentage { get; set; }
        public double PredictedMemoryUtilizationPercentage { get; set; }
        public double PredictedStorageUtilizationPercentage { get; set; }
        public int NumberOfCpuCoresAvailable { get; set; }
        public double MemoryInTBAvailable { get; set; }
        public double StorageInTBAvailable { get; set; }
        public int NumberOfCpuCoresUsed { get; set; }
        public double MemoryInTBUsed { get; set; }
        public double StorageInTBUsed { get; set; }
        public int NumberOfCpuCoresFree { get; set; }
        public double MemoryInTBFree { get; set; }
        public double StorageInTBFree { get; set; }
        public string ConfidenceRating { get; set; }
    }
}