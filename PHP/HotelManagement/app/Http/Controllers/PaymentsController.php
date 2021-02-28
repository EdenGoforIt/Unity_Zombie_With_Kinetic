<?php

namespace App\Http\Controllers;

use App\Payment;
use Illuminate\Http\Request;
use App\Customer;
use App\Room;
use App\Booking;

class PaymentsController extends Controller
{
    // ['customer_id','room_id','card_holder','card_number','expiration_date','payment_type','amount','payment_date'];
    public function index()
    {
        $payments = Payment::all();
        return view('admin.payments.index', compact('payments'));
    }

    public function create()
    {
        $customers = Customer::get()->pluck('full_name', 'id')->prepend(trans('quickadmin.qa_please_select'), '');
        $bookings = Booking::get()->pluck('id')->prepend(trans('quickadmin.qa_please_select'), '');

        return view('admin.payments.create', compact('customers', 'bookings'));
    }

    public function store(Request $request)
    {


        $payment = Payment::create([
            'customer_id' => $request->customer_id,
            'booking_id' => $request->booking_id,
            'card_holder' => $request->card_holder,
            'card_number' => $request->card_number,
            'expiration_date' => $request->expiration_date,
            'payment_type' => $request->payment_type,
            'amount' => $request->amount,
            'payment_date' => $request->payment_date,
            'charge_back'=>$request->charge_back,

        ]);
        return redirect('/admin/payments');
    }

    /**
     * Show the form for editing category.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {

        $payment = Payment::findOrFail($id);
        $customers = Customer::get()->pluck('first_name', 'id')->prepend(trans('quickadmin.qa_please_select'), '');
        $bookings = Booking::get()->pluck('id')->prepend(trans('quickadmin.qa_please_select'), '');

        return view('admin.payments.edit', compact('payment', 'customers', 'bookings'));
    }

    /**
     * Update category in storage.
     *
     * @param  \App\Http\Requests\UpdateCountriesRequest  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {

        $payment = Payment::findOrFail($id);
        $payment->update($request->all());
        return redirect()->route('admin.payments.index');
    }


    /**
     * Remove Booking from storage.
     *
     * @param  int $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {

        $payment = Payment::findOrFail($id);
        $payment->delete();

        return redirect()->route('admin.payments.index');
    }

    /**
     * Delete all selected Category at once.
     *
     * @param Request $request
     */
    public function massDestroy(Request $request)
    {
        if (!Gate::allows('payment_delete')) {
            return abort(401);
        }
        if ($request->input('ids')) {
            $entries = Payment::whereIn('id', $request->input('ids'))->get();

            foreach ($entries as $entry) {
                $entry->delete();
            }
        }
    }
    public function show($id)
    {

        $payment = Payment::findOrFail($id);

        return view('admin.payments.show', compact('payment'));
    }

    /**
     * Restore Category from storage.
     *
     * @param  int $id
     * @return \Illuminate\Http\Response
     */
    public function restore($id)
    {
        if (!Gate::allows('payment_delete')) {
            return abort(401);
        }
        $payment = Payment::onlyTrashed()->findOrFail($id);
        $payment->restore();

        return redirect()->route('admin.payments.index');
    }

    /**
     * Permanently delete Category from storage.
     *
     * @param  int $id
     * @return \Illuminate\Http\Response
     */
    public function perma_del($id)
    {
        if (!Gate::allows('payment_delete')) {
            return abort(401);
        }
        $payment = Payment::onlyTrashed()->findOrFail($id);
        $payment->forceDelete();

        return redirect()->route('admin.payments.index');
    }
}
