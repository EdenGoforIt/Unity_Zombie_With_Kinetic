<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class Create1516728224BookingsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {

        Schema::create('bookings', function (Blueprint $table) {
            $table->bigIncrements('id');
            $table->datetime('time_from')->nullable();
            $table->datetime('time_to')->nullable();
            $table->text('additional_information')->nullable();
            $table->boolean('parking')->default(0);
            $table->enum('status',['None','CheckedIn','CheckedOut']);
            $table->timestamps();
            $table->softDeletes(); 
            $table->unsignedBigInteger('customer_id');
            $table->foreign('customer_id')->references('id')->on('customers'); 
            $table->unsignedBigInteger('room_id');
            $table->foreign('room_id')->references('id')->on('rooms'); 
            $table->index(['deleted_at']);
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('bookings');
    }
}
