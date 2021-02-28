<?php

use Illuminate\Database\Seeder;

class AgencySeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
      $items = [
        [
          'name' => 'Booking.com',
          'address' => 'Amsterdam, Netherlands',
          'phone' => '0217495243',
          'details' => 'Booking.com is a travel fare aggregator website and travel metasearch engine for lodging reservations.'
        ],
        [
          'name' => 'Kayak',
          'address' => 'India',
          'phone' => '0267826434',
          'details' => 'Kayak’s hotel search offers a clean, easy-to-use interface with many available filters.'
        ],
        [
          'name' => 'Hotels.com',
          'address' => 'Japan',
          'phone' => '0236477225',
          'details' => 'Hotels.com helps you find the best hotel deals via tons of filters that let you narrow down your search.'
        ],
        [
          'name' => 'HotelsCombined',
          'address' => 'German',
          'phone' => '0216477244',
          'details' => 'HotelsCombined, one of the best hotel booking sites, is a metasearch tool that searches a wide range of sources to find the best hotel deals, including OTAs, as well as the hotels’ own sites.'
        ],
      ];
      foreach($items as $item) {
        App\Agency::create($item);
      }
    }
}
