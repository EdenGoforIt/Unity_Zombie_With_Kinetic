@inject('request', 'Illuminate\Http\Request')
@extends('layouts.app')

@section('content')
<h3 class="page-title">Payment History</h3>

<p>
    <a href="{{ route('admin.payments.create') }}" class="btn btn-success">@lang('quickadmin.qa_add_new')</a>

</p>


<p>
    <ul class="list-inline">
        <li><a href="{{ route('admin.payments.index') }}" style="{{ request('show_deleted') == 1 ? '' : 'font-weight: 700' }}">@lang('quickadmin.qa_all')</a></li> |
        <li><a href="{{ route('admin.payments.index') }}?show_deleted=1" style="{{ request('show_deleted') == 1 ? 'font-weight: 700' : '' }}">@lang('quickadmin.qa_trash')</a></li>
    </ul>
</p>



<div class="panel panel-default">
    <div class="panel-heading">
        @lang('quickadmin.qa_list')
    </div>

    <div class="panel-body table-responsive">
        <table class="table table-bordered table-striped">
            <thead>
                <tr>

                    @if ( request('show_deleted') != 1 )<th style="text-align:center;"><input type="checkbox" id="select-all" /></th>@endif
                   
                    <th>Customer</th>
                    <th>Reference Number</th>
                    <th>Card Holder</th>
                    <th>Card Number</th>
                    <th>Expiration Date</th>
                    <th>Payment Type</th>
                    <th>Payment Date</th>
                    <th>Charge Back</th>
                    <th>Amount</th>

                    <th>&nbsp;</th>

                    <th>&nbsp;</th>

                </tr>
            </thead>

            <tbody>
   
                @if (count($payments) > 0)
                @foreach ($payments as $payment)
                <tr data-entry-id="{{ $payment->id }}">

                    @if ( request('show_deleted') != 1 )<td></td>@endif
  <!-- ['customer_id','room_id','card_holder','card_number','expiration_date','payment_type','amount','payment_date']; -->

                    <td field-key='name'>{{ $payment->customer_id }}</td>
                    <td field-key='address'>{{ $payment->booking_id }}</td>
                    <td field-key='phone'>{{ $payment->card_holder }}</td>
                    <td field-key='details'>{{ $payment->card_number }}</td>
                    <td field-key='address'>{{ $payment->expiration_date }}</td>
                    <td field-key='phone'>{{ $payment->payment_type }}</td>
                    <td field-key='details'>{{ $payment->payment_date }}</td>
                    <td field-key='charge_back'>{{ $payment->charge_back }}</td>
                    <td field-key='amount'>{{ $payment->amount }}</td>
                    @if( request('show_deleted') == 1 )
                    <td>
                        @can('payment_delete')
                        {!! Form::open(array(
                        'style' => 'display: inline-block;',
                        'method' => 'POST',
                        'onsubmit' => "return confirm('".trans("quickadmin.qa_are_you_sure")."');",
                        'route' => ['admin.payments.restore', $payment->id])) !!}
                        {!! Form::submit(trans('quickadmin.qa_restore'), array('class' => 'btn btn-xs btn-success')) !!}
                        {!! Form::close() !!}
                        @endcan
                        @can('payment_delete')
                        {!! Form::open(array(
                        'style' => 'display: inline-block;',
                        'method' => 'DELETE',
                        'onsubmit' => "return confirm('".trans("quickadmin.qa_are_you_sure")."');",
                        'route' => ['admin.payments.perma_del', $payment->id])) !!}
                        {!! Form::submit(trans('quickadmin.qa_permadel'), array('class' => 'btn btn-xs btn-danger')) !!}
                        {!! Form::close() !!}
                        @endcan
                    </td>
                    @else
                    <td>

                        <a href="{{ route('admin.payments.show',[$payment->id]) }}" class="btn btn-xs btn-primary">@lang('quickadmin.qa_view')</a>


                        <a href="{{ route('admin.payments.edit',[$payment->id]) }}" class="btn btn-xs btn-info">@lang('quickadmin.qa_edit')</a>


                        {!! Form::open(array(
                        'style' => 'display: inline-block;',
                        'method' => 'DELETE',
                        'onsubmit' => "return confirm('".trans("quickadmin.qa_are_you_sure")."');",
                        'route' => ['admin.payments.destroy', $payment->id])) !!}
                        {!! Form::submit(trans('quickadmin.qa_delete'), array('class' => 'btn btn-xs btn-danger')) !!}
                        {!! Form::close() !!}

                    </td>
                    @endif
                </tr>
                @endforeach
                @else
                <tr>
                    <td colspan="8">@lang('quickadmin.qa_no_entries_in_table')</td>
                </tr>
                @endif
            </tbody>
        </table>
    </div>
</div>
@stop

@section('javascript')
<script>
    @if(request('show_deleted') != 1) window.route_mass_crud_entries_destroy = '{{ route('admin.payments.mass_destroy') }}';
    @endif
</script>
@endsection