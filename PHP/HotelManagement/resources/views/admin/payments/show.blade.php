@extends('layouts.app')

@section('content')
    <h3 class="page-title">Payment History</h3>

    <div class="panel panel-default">
        <div class="panel-heading">
            @lang('quickadmin.qa_view')
        </div>

        <div class="panel-body table-responsive">
            <div class="row">
                <div class="col-md-6">
                    <table class="table table-bordered table-striped">
                        <tr>
                              <!-- ['customer_id','room_id','card_holder','card_number','expiration_date','payment_type','amount','payment_date']; -->

                            <th>Customer</th>
                            <td field-key='customer_id'>{{ $payment->customer->first_name or '' }}</td>
                        </tr>
                        <tr>
                            <th>Reference Number</th>
                            <td field-key='booking_id'>{{ $payment->booking_id}}</td>
                        </tr>
                        <tr>
                            <th>Card Holder</th>
                            <td field-key='card_holder'>{{ $payment->card_holder }}</td>
                        </tr>
                        <tr>
                            <th>Card Number</th>
                            <td field-key='card_number'>{{ $payment->card_number }}</td>
                        </tr>
                        <tr>
                            <th>Expiration Date</th>
                            <td field-key='expiration_date'>{!! $payment->expiration_date !!}</td>
                        </tr>
                        <tr>
                            <th>Payment Type</th>
                            <td field-key='payment_type'>{!! $payment->payment_type !!}</td>
                        </tr>
                        <tr>
                            <th>Payment Date</th>
                            <td field-key='payment_date'>{!! $payment->payment_date !!}</td>
                        </tr>
                        <tr>
                            <th>Charge Back</th>
                            <td field-key='amount'>{!! $payment->charge_back !!}</td>
                        </tr>
                        <tr>
                            <th>Amount</th>
                            <td field-key='amount'>{!! $payment->amount !!}</td>
                        </tr>
                    </table>
                </div>
            </div>

            <p>&nbsp;</p>

            <a href="{{ route('admin.payments.index') }}" class="btn btn-default">@lang('quickadmin.qa_back_to_list')</a>
        </div>
    </div>
@stop
