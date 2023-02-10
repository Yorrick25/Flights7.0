import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookDto, BookingRm } from '../api/models';
import { BookingService } from '../api/services';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-my-bookings',
  templateUrl: './my-bookings.component.html',
  styleUrls: ['./my-bookings.component.css']
})
export class MyBookingsComponent implements OnInit {

  bookings!: BookingRm[];
  constructor(private bookingService: BookingService,
    private authService: AuthService,
    private router: Router ) { }

  ngOnInit(): void {
    if (!this.authService.currentUser?.email) {
      this.router.navigate(['./register-passenger'])
    }
    this.bookingService.listBooking({email: this.authService.currentUser?.email ?? ''})
      .subscribe(result => this.bookings = result, this.handleError);
  }

  private handleError(err: any) {
    console.log("Response Error, Status:", err.status);
    console.log("Response Error, Status Text:", err.statusText);
    console.log(err);

  }

  cancel(booking: BookingRm) {
    const dto: BookDto = {
      flightId: booking.flightId,
      numberOfSeats: booking.numberOfBookedSeats,
      passengerEmail: booking.passengerEmail
    }

    this.bookingService.cancelBooking({ body: dto })
      .subscribe(_ =>  this.bookings = this.bookings.filter(b => b != booking)
        , this.handleError);
  }
}
