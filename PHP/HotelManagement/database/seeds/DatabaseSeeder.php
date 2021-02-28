<?php

use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        
        $this->call(CountrySeed::class);
        $this->call(RoleSeed::class);
        $this->call(UserSeed::class);
        $this->call(CustomersSeed::class);
        $this->call(ChecksheetSeeder::class);
        $this->call(RoomSeeder::class);
        $this->call(AgencySeeder::class);
        $this->call(HouseKeeperSeeder::class);
        $this->call(CompanySeeder::class);

    }
}
