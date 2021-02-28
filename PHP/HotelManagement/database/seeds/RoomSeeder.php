<?php

use Illuminate\Database\Seeder;

class RoomSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        //['room_number', 'floor', 'description',,'room_type',category_id','room_status','checksheet_id'];
        $items = [
            ['room_number' => 1, 'floor' => 1,'description'=>'A single room','room_type'=>'single','room_status'=>'vacantClean'],
            ['room_number' => 2, 'floor' => 2,'description'=>'A two bed rooms','room_type'=>'twoBedroooms','room_status'=>'vacantDirty' ],
            ['room_number' => 3, 'floor' => 3,'description'=>'A two bed room','room_type'=>'twoBedroooms','room_status'=>'occupiedClean' ],
            ['room_number' => 4, 'floor' => 4,'description'=>'A superior room','room_type'=>'superior','room_status'=>'occupiedService' ],
        ];

        foreach ($items as $item) {
            \App\Room::create($item);
        }
    }
}
