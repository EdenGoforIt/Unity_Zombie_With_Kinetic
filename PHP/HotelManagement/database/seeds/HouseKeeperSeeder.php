<?php

use Illuminate\Database\Seeder;

class HouseKeeperSeeder extends Seeder
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
              'name' => 'Hung',
       
            ],
            [
                'name' => 'Eden',
         
              ],
              [
                'name' => 'Jayden',
         
              ],
            
          ];
          foreach ($items as $item) {
            \App\Housekeeper::create($item);
          }
    }
}
