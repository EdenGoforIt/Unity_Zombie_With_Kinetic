@extends('layouts.app')

@section('content')
<h3 class="page-title">Check Sheet</h3>
<!-- ['name','address','phone','details']; -->
<div class="panel panel-default">
    <div class="panel-heading">
        @lang('quickadmin.qa_view')
    </div>

    <div class="panel-body table-responsive">
        <div class="row">
            <div class="col-md-6">
                <table class="table table-bordered table-striped">
                    <tr>
                        <th>Start Time</th>
                        <td field-key='name'>{{ $checksheet->start_time }}</td>
                    </tr>
                    <tr>
                        <th>End Time</th>
                        <td field-key='name'>{{ $checksheet->end_time }}</td>
                    </tr>
                    <tr>
                        <th>Total Cycle</th>
                        <td field-key='name'>{{ $checksheet->total_cycle }}</td>
                    </tr>
                    <tr>
                        <th>Room</th>
                        <td field-key='name'>{{ $checksheet->room_id }}</td>
                    </tr>
                    <tr>
                        <th>House Keeper</th>
                        <td field-key='name'>{{ $checksheet->housekeeper_id }}</td>
                    </tr>

                </table>
            </div>
        </div><!-- Nav tabs -->


        <!-- Tab panes -->

        <p>&nbsp;</p>

        <a href="{{ route('admin.checksheets.index') }}" class="btn btn-default">@lang('quickadmin.qa_back_to_list')</a>
    </div>
</div>
@stop