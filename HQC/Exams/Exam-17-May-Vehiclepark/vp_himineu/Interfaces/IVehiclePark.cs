namespace VehicleParkSystem.Interfaces
{
    using System;
    using Models;

    /// <summary>
    /// Vehicle park supporting insertion of car, motorbike and truck. Contains info
    /// for the vehicle and support exiting of the park as well as queries for
    /// finding vehicle by license place or owner.
    /// </summary>
    public interface IVehiclePark
    {
        /// <summary>
        /// Inserts car to the parking system.
        /// </summary>
        /// <param name="car">Car to be inserted.</param>
        /// <param name="sector">Parking sector.</param>
        /// <param name="placeNumber">Parking place.</param>
        /// <param name="startTime">Duration for parking.</param>
        /// <returns>Status message.</returns>
        string InsertCar(Car car, int sector, int placeNumber, DateTime startTime);
        
        /// <summary>
        /// Inserts motorbike to the parking system.
        /// </summary>
        /// <param name="motorbike">Motorbike to be inserted.</param>
        /// <param name="sector">Parking sector.</param>
        /// <param name="placeNumber">Parking place.</param>
        /// <param name="startTime">Duration for parking.</param>
        /// <returns>Status message.</returns>
        string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime);
        
        /// <summary>
        /// Inserts Truck to the parking system.
        /// </summary>
        /// <param name="truck">Truck to be inserted.</param>
        /// <param name="sector">Parking sector.</param>
        /// <param name="placeNumber">Parking place.</param>
        /// <param name="startTime">Duration for parking.</param>
        /// <returns>Status message.</returns>
        string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime);
        
        /// <summary>
        /// Vehicle exits the park.
        /// </summary>
        /// <param name="licensePlate">License plate of the vehicle.</param>
        /// <param name="endTime">Actual parking duration.</param>
        /// <param name="payedMoney">Payed money.</param>
        /// <returns>Status message.</returns>
        string ExitVehicle(string licensePlate, DateTime endTime, decimal payedMoney);
        
        /// <summary>
        /// Gets status of the parking spots in the park.
        /// </summary>
        /// <returns>Status message.</returns>
        string GetStatus();
        
        /// <summary>
        /// Find vehicle by given license plate.
        /// </summary>
        /// <param name="licensePlate">License plate of the vehicle.</param>
        /// <returns>Status message or vehicle status.</returns>
        string FindVehicle(string licensePlate);
        
        /// <summary>
        /// Finds all vehicles by given vehicle owner.
        /// </summary>
        /// <param name="owner">Owner of the vehicles.</param>
        /// <returns>Status message or vehicles status.</returns>
        string FindVehiclesByOwner(string owner);
    }
}