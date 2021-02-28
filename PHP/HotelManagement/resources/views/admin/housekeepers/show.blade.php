@extends('layouts.app')

@section('content')
<h3 class="page-title">House Keeper</h3>
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
                        <th>Name</th>
                        <td field-key='name'>{{ $housekeeper->name }}</td>
                    </tr>

                </table>
            </div>
        </div><!-- Nav tabs -->


        <!-- Tab panes -->

        <p>&nbsp;</p>

        <a href="{{ route('admin.housekeepers.index') }}" class="btn btn-default">@lang('quickadmin.qa_back_to_list')</a>
    </div>
</div>
@stop