﻿using HotelBookingLibrary.Data;
using HotelBookingLibrary.Interfaces;
using HotelBookingLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingLibrary.Repositories
{
	public class RoomReservationRepository(HotelBookingDbContext context) : IRoomReservationRepository
	{
		private readonly HotelBookingDbContext _context = context;

		public async Task Add(RoomReservation entity)
		{
			_context.RoomsReservations.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(RoomReservation entity)
		{
			_context.RoomsReservations.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<RoomReservation>> GetAll()
		{
			return await _context.RoomsReservations.ToListAsync();
		}

		public async Task<IEnumerable<RoomReservation>> GetAllByRoomId(int roomId)
		{
			return await _context.RoomsReservations.Where(rr => rr.HotelRoomId == roomId).ToListAsync();
		}

		public async Task<RoomReservation> GetByRoomIdAndStartDate(int roomId, DateTime startDate)
		{
			return await _context.RoomsReservations.Where(rr => rr.HotelRoomId == roomId && rr.StartDateTime.Date == startDate.Date).FirstAsync();
		}

		public async Task Update(RoomReservation entity)
		{
			_context.RoomsReservations.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
