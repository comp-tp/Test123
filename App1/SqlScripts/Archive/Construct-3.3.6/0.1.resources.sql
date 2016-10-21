update resources
set RelativeUriTemplateFull='/v4/inspections/availableDates?lang={lang}&typeId={typeId}&recordId={recordId}&startDate={startDate}&limit={limit}&offset={offset}&validateCutOffTime={validateCutOffTime}&validateScheduleNumOfDays={validateScheduleNumOfDays}',
proxyApi='/apis/v4/inspections/availableDates?lang={lang}&typeId={typeId}&recordId={recordId}&startDate={startDate}&limit={limit}&offset={offset}&validateCutOffTime={validateCutOffTime}&validateScheduleNumOfDays={validateScheduleNumOfDays}'
where api='/v4/inspections/availableDates'
