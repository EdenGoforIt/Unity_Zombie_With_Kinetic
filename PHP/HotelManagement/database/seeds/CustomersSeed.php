<?php

use Illuminate\Database\Seeder;

class CustomersSeed extends Seeder
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
          'id' => 1,
          'first_name' => 'Sean',
          'last_name' => 'Stanley',
          'address' => '8116 Adams St',
          'phone' => '0450492692',
          'email' => 'Sean.Stanley@example.com',
          'country_id' => 10,
        ],
        [
          'id' => 2,
          'first_name' => 'Sharlene',
          'last_name' => 'Brooks',
          'address' => '8162 Pockrus Page Rd',
          'phone' => '8986061604',
          'email' => 'Sharlene.Brooks@example.com',
          'country_id' => 25
        ],
        [
          'id' => 3,
          'first_name' => 'Julio',
          'last_name' => 'Brewer',
          'address' => '4008 Valwood Pkwy',
          'phone' => '2773877431',
          'email' => 'Julio.Brewer@example.com',
          'country_id' => 17
        ],
        [
          'id' => 4,
          'first_name' => 'Danielle',
          'last_name' => 'Shaw',
          'address' => '233 Camden Ave',
          'phone' => '7843082958',
          'email' => 'Danielle.Shaw@example.com',
          'country_id' => 23
        ],
        [
          'id' => 5,
          'first_name' => 'Ellen',
          'last_name' => 'Elliott',
          'address' => '6519 Mcgowen St',
          'phone' => '2418688869',
          'email' => 'Ellen.Elliott@example.com',
          'country_id' => 33
        ],
      ];
      foreach ($items as $item) {
        \App\Customer::create($item);
      }
    }
}
