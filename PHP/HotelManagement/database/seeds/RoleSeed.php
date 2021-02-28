<?php

use Illuminate\Database\Seeder;

class RoleSeed extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $items = [
            ['id' => 1, 'title' => 'manager',],
            ['id' => 2, 'title' => 'reception',],
            ['id' => 3, 'title' => 'housekeeper',]
        ];

        foreach ($items as $item) {
            \App\Role::create($item);
        }
    }
}
