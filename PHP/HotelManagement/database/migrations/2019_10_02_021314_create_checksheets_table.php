<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateChecksheetsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('check_sheets', function (Blueprint $table) {
            $table->bigIncrements('id');
            $table->datetime('start_time');
            $table->datetime('end_time');
            $table->integer('total_cycle');
          
            $table->unsignedBigInteger('room_id');
             $table->unsignedBigInteger('housekeeper_id');
 
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('checksheets');
    }
}
